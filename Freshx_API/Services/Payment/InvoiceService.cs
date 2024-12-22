using AutoMapper;
using Freshx_API.Dtos.Payment;
using Freshx_API.Interfaces.Payment;
using Freshx_API.Models;

namespace Freshx_API.Services.Payment
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMedicalServiceRequestRepository _medicalServiceRequestRepository;
        private readonly IMapper _mapper;

        public InvoiceService(IInvoiceRepository invoiceRepository,
                              IMedicalServiceRequestRepository medicalServiceRequestRepository,
                              IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _medicalServiceRequestRepository = medicalServiceRequestRepository;
            _mapper = mapper;
        }
        //Logic tạo và tính toán hóa đơn
        public async Task<InvoiceDTO> CreateInvoiceAsync(InvoiceDTO invoiceDTO)
        {
            var invoice = _mapper.Map<Invoice>(invoiceDTO);
            var createdInvoice = await _invoiceRepository.CreateInvoiceAsync(invoice);

            foreach (var serviceRequest in invoiceDTO.ServiceRequests)
            {
                var medicalServiceRequest = new MedicalServiceRequest
                {
                    ServiceId = serviceRequest.ServiceId,
                    Quantity = serviceRequest.Quantity,
                    ServiceUnitPrice = serviceRequest.ServiceUnitPrice,
                    ServiceTotalAmount = serviceRequest.ServiceUnitPrice * serviceRequest.Quantity,
                    IsPaid = false,
                    InvoiceId = createdInvoice.InvoiceId
                };
                await _medicalServiceRequestRepository.CreateMedicalServiceRequestAsync(medicalServiceRequest);
            }

            var createdInvoiceDTO = _mapper.Map<InvoiceDTO>(createdInvoice);
            return createdInvoiceDTO;
        }
  
        public async Task<InvoiceDTO> GetInvoiceByIdAsync(int invoiceId)
        {
            var invoice = await _invoiceRepository.GetInvoiceByIdAsync(invoiceId);
            return _mapper.Map<InvoiceDTO>(invoice);
        }
        //Logic xử lý trạng thái hóa đơn
        public async Task MarkInvoiceAsPaidAsync(int invoiceId)
        {
            var invoice = await _invoiceRepository.GetInvoiceByIdAsync(invoiceId);
            invoice.IsPaid = true;

            var serviceRequests = await _medicalServiceRequestRepository.GetRequestsByInvoiceIdAsync(invoiceId);
            foreach (var request in serviceRequests)
            {
                request.IsPaid = true;
            }

            await _invoiceRepository.UpdateInvoiceAsync(invoice);
        }


    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Freshx_API.Dtos.Invoice;
using Freshx_API.Models;
using Freshx_API.Repositories;
using Humanizer;
using NuGet.Protocol.Core.Types;

namespace Freshx_API.Services
{
    public class InvoiceService
    {
        private readonly IInvoiceRepository _repository;
        private readonly IMapper _mapper;

        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            _repository = invoiceRepository;
        }

        public async Task<IEnumerable<Invoice>> GetAllInvoicesAsync()
        {
            return await _repository.GetAllInvoicesAsync();
        }

        public async Task<Invoice?> GetInvoiceByIdAsync(int id)
        {
            return await _repository.GetInvoiceByIdAsync(id);
        }

        public async Task<IEnumerable<Invoice>> GetInvoicesByPatientIdAsync(int patientId)
        {
            return await _repository.GetInvoicesByPatientIdAsync(patientId);
        }

        public async Task AddInvoiceAsync(Invoice invoice)
        {
            await _repository.AddInvoiceAsync(invoice);
            await _repository.SaveChangesAsync();
        }

        // cap nhat invoice theo id
        public async Task<bool> UpdateInvoiceAsync(int id, InvoiceUpdateDto dto)
        {
            var existInvoice = await _repository.GetInvoiceByIdAsync(id);

            if(existInvoice == null)
                return false;
            await _repository.UpdateInvoiceAsync(existInvoice);
            await _repository.SaveChangesAsync();

            _mapper.Map(dto, existInvoice);
            await _repository.UpdateInvoiceAsync(existInvoice);
            return true;
        }

        // xoa invoice theo id
        public async Task<bool> DeleteInvoiceAsync(int id)
        {
            var invoice = await _repository.GetInvoiceByIdAsync(id);

            if (invoice == null)
                return false;

            await _repository.DeleteInvoiceAsync(id);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}

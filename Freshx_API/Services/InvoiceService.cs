using AutoMapper;
using Freshx_API.DTOs;
using Freshx_API.Interfaces;
using Freshx_API.Interfaces.Invoice;
using Freshx_API.Models;
using Freshx_API.Repositories;

namespace Freshx_API.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;

        public InvoiceService(IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InvoiceDto>> GetAllInvoicesAsync(string? searchKeyword = null)
        {
            var invoices = await _invoiceRepository.GetAllAsync(searchKeyword);
            return _mapper.Map<IEnumerable<InvoiceDto>>(invoices);
        } 

        public async Task<InvoiceDto?> GetInvoiceByIdAsync(int id)
        {
            var invoice = await _invoiceRepository.GetByIdAsync(id);
            return invoice == null ? null : _mapper.Map<InvoiceDto>(invoice);
        }

        public async Task<InvoiceDto> CreateInvoiceAsync(CreateInvoiceDto createInvoiceDto)
        {
            var invoice = _mapper.Map<Invoice>(createInvoiceDto);

            invoice.CreatedDate = DateTime.Now;
            invoice.CreatedTime = DateTime.Now;
            invoice.IsDeleted = 0;

            var createdInvoice = await _invoiceRepository.CreateAsync(invoice);
            await _invoiceRepository.SaveChangesAsync();

            return _mapper.Map<InvoiceDto>(createdInvoice);
        }

        public async Task<InvoiceDto?> UpdateInvoiceAsync(int id, UpdateInvoiceDto updateInvoiceDto)
        {
            var existingInvoice = await _invoiceRepository.GetByIdAsync(id);

            if (existingInvoice == null)
                return null;

            _mapper.Map(updateInvoiceDto, existingInvoice);
            existingInvoice.UpdatedDate = DateTime.Now;

            var updatedInvoice = await _invoiceRepository.UpdateAsync(existingInvoice);
            await _invoiceRepository.SaveChangesAsync();

            return updatedInvoice == null ? null : _mapper.Map<InvoiceDto>(updatedInvoice);
        }

        public async Task<bool> DeleteInvoiceAsync(int id)
        {
            var result = await _invoiceRepository.DeleteAsync(id);

            if (result)
                await _invoiceRepository.SaveChangesAsync();

            return result;
        }
    }
}
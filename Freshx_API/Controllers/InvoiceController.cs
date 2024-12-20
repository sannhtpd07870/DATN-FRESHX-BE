using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Freshx_API.Models;
using Freshx_API.Services;
using AutoMapper;

namespace Freshx_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly InvoiceService _service;

        public InvoiceController(InvoiceService invoiceService, ILogger<InvoiceController> logger)
        {
            _service = invoiceService;
        }

        [HttpGet]
        public async Task<IEnumerable<Invoice>> GetAllInvoices()
        {
            return await _service.GetAllInvoicesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Invoice>> GetInvoiceById(int id)
        {
            var invoice = await _service.GetInvoiceByIdAsync(id);
            if (invoice == null)
                return NotFound();
            return invoice;
        }

        [HttpPost]
        public async Task<ActionResult> AddInvoice(Invoice invoice)
        {
            await _service.AddInvoiceAsync(invoice);
            return CreatedAtAction(nameof(GetInvoiceById), new { id = invoice.InvoiceId }, invoice);
        }

        // Cap nhat thong tin invoice qua id
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInvoice(int id, Invoice invoice)
        {
            if (id != invoice.InvoiceId)
                return BadRequest();

            await _service.UpdateInvoiceAsync(invoice);
            return NoContent();
        }

        // Xoa invoice qua id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            var isDeletedInvoice = await _service.DeleteInvoiceAsync(id);

            if (!isDeletedInvoice)
            {
                return NotFound("Hoá đơn không tồn tại.");
            }

            return NoContent();
        }
    }
}

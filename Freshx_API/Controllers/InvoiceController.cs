using Microsoft.AspNetCore.Mvc;
using Freshx_API.DTOs;
using Freshx_API.Interfaces;
using Freshx_API.Interfaces.Invoice;

namespace Freshx_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoicesController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceDto>>> GetInvoices()
        {
            var invoices = await _invoiceService.GetAllInvoicesAsync();
            return Ok(invoices);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceDto>> GetInvoice(int id)
        {
            var invoice = await _invoiceService.GetInvoiceByIdAsync(id);

            if (invoice == null)
                return NotFound();

            return Ok(invoice);
        }

        [HttpPost]
        public async Task<ActionResult<InvoiceDto>> CreateInvoice(CreateInvoiceDto createInvoiceDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdInvoice = await _invoiceService.CreateInvoiceAsync(createInvoiceDto);
            return CreatedAtAction(nameof(GetInvoice), new { id = createdInvoice.InvoiceId }, createdInvoice);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<InvoiceDto>> UpdateInvoice(int id, UpdateInvoiceDto updateInvoiceDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedInvoice = await _invoiceService.UpdateInvoiceAsync(id, updateInvoiceDto);

            if (updatedInvoice == null)
                return NotFound();

            return Ok(updatedInvoice);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            var result = await _invoiceService.DeleteInvoiceAsync(id);

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
using Freshx_API.Dtos.Payment;
using Freshx_API.Interfaces.Payment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Freshx_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public PaymentController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateInvoice([FromBody] InvoiceDTO invoiceDTO)
        {
            var createdInvoice = await _invoiceService.CreateInvoiceAsync(invoiceDTO);
            return CreatedAtAction(nameof(GetInvoice), new { id = createdInvoice.InvoiceId }, createdInvoice);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInvoice(int id)
        {
            var invoice = await _invoiceService.GetInvoiceByIdAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }
            return Ok(invoice);
        }

        [HttpPut("{id}/pay")]
        public async Task<IActionResult> MarkAsPaid(int id)
        {
            await _invoiceService.MarkInvoiceAsPaidAsync(id);
            return NoContent();
        }
    }

}

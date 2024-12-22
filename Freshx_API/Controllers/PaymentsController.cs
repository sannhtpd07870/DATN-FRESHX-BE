using Freshx_API.Dtos.CommonDtos;
using Freshx_API.Dtos.DrugCatalog;
using Freshx_API.Dtos.Payments;
using Freshx_API.Interfaces.Payments;
using Freshx_API.Services.CommonServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Sprache;

namespace Freshx_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly IBillService _billService;

        public PaymentsController(IBillService billService)
        {
            _billService = billService;
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<BillDto>>> CreateBill([FromBody] BillDto billDto)
        {          
            try
            {
                var createdBill = await _billService.CreateBillAsync(billDto);
                return StatusCode(StatusCodes.Status201Created,
                   ResponseFactory.Success(Request.Path, CreateBill, "Tạo hóa đơn thành công.", StatusCodes.Status201Created));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                        ResponseFactory.Error<string>(Request.Path, "Một lỗi đã xảy ra.", StatusCodes.Status500InternalServerError));
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<BillDto>>> GetBill(int id)
        {
            var bill = await _billService.GetBillAsync(id);
            if (bill == null)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                        ResponseFactory.Error<DrugCatalogDetailDto>(Request.Path, "Không tìm thấy hóa đơn.", StatusCodes.Status404NotFound));
            }
            return StatusCode(StatusCodes.Status200OK , bill);
        }

        [HttpPost("payment")]
        public async Task<ActionResult<ApiResponse<BillDto>>> AddPayment([FromBody] PaymentDto paymentDto)
        {
            try
            {
                await _billService.AddPaymentAsync(paymentDto);
                return StatusCode(StatusCodes.Status200OK,
    ResponseFactory.Success(Request.Path, paymentDto, "Payment Success.", StatusCodes.Status200OK));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ResponseFactory.Error<string>(Request.Path, "Một lỗi đã xảy ra.", StatusCodes.Status500InternalServerError));
            }

        }
    }
}

    using AutoMapper;
using Freshx_API.Dtos.Payments;
using Freshx_API.Interfaces.Payments;
using Freshx_API.Models;

namespace Freshx_API.Services
{
    public class BillingService : IBillingService
    {
        private readonly IBillingRepository _repository;
        private readonly IMapper _mapper;


        public BillingService(IBillingRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BillDto> CreateBillAsync(BillDto billDto)
        {
            // Tính tổng tiền từ danh sách chi tiết hóa đơn
            if (billDto.BillDetails != null && billDto.BillDetails.Any())
            {
                billDto.TotalAmount = billDto.BillDetails
                    .Sum(detail => (detail.Quantity ?? 0) * (detail.UnitPrice ?? 0));
            }
            else
            {
                billDto.TotalAmount = 0; // Nếu không có chi tiết hóa đơn, đặt TotalAmount là 0
            }

            var bill = _mapper.Map<Bill>(billDto);
            bill.PaymentStatus = "Chưa thanh toán";
            
            var createdBill = await _repository.AddBillAsync(bill);
            return _mapper.Map<BillDto>(createdBill);
        }

        public async Task<BillDto> GetBillByIdAsync(int billId)
        {
            var bill = await _repository.GetBillByIdAsync(billId);
            return _mapper.Map<BillDto>(bill);
        }

        public async Task<IEnumerable<BillDto>> GetAllBillsAsync()
        {
            var bills = await _repository.GetAllBillsAsync();
            return _mapper.Map<IEnumerable<BillDto>>(bills);
        }

        public async Task<PaymentDto> ProcessPaymentAsync(PaymentDto paymentDto)
        {
            // Kiểm tra giá trị âm
            if (paymentDto.AmountPaid <= 0)
            {
                throw new ArgumentException("Số tiền thanh toán phải lớn hơn 0.", nameof(paymentDto.AmountPaid));
            }

            var payment = _mapper.Map<Payment>(paymentDto);
            await _repository.AddPaymentAsync(payment);

            var bill = await _repository.GetBillByIdAsync(payment.BillId);
            if (bill != null)
            {
                // Kiểm tra số tiền thanh toán có vượt quá tổng tiền cần thanh toán không
                if (payment.AmountPaid > bill.TotalAmount)
                {
                    throw new InvalidOperationException("Số tiền thanh toán vượt quá tổng số tiền hóa đơn.");
                }
                bill.TotalAmount -= payment.AmountPaid;

                // Cập nhật trạng thái thanh toán
                if (bill.TotalAmount > 0)
                {
                    bill.PaymentStatus = "Đã thanh toán một phần";
                }
                else
                {
                    bill.PaymentStatus = "Đã thanh toán";
                    bill.TotalAmount = 0; // Đảm bảo không có giá trị âm
                }

                await _repository.UpdateAsync(bill);
            }

            return _mapper.Map<PaymentDto>(payment);
        }


        public async Task<BillDto> UpdateBillAsync(int billId, BillDtoUpdate billDtoUpdate)
        {
            var bill = await _repository.GetBillByIdAsync(billId);
            if (bill == null)
            {
                return null; 
            }

            _mapper.Map(billDtoUpdate, bill);
            var updatedBill = await _repository.UpdateAsync(bill);

            return _mapper.Map<BillDto>(updatedBill);
        }

        public async Task<bool> DeleteBillAsync(int billId)
        {
            var bill = await _repository.GetBillByIdAsync(billId);
            if (bill == null)
            {
                return false; 
            }

            await _repository.DeleteAsync(bill);
            return true; 
        }
        public async Task<BillDto> GetBillWithDetailsAsync(int billId)
        {
            var bill = await _repository.GetBillWithDetailsAsync(billId);
            return _mapper.Map<BillDto>(bill); 
        }
        public async Task<IEnumerable<object>> GetStatisticsAsync(DateTime startDate, DateTime endDate, string grouping)
        {
            return await _repository.GetStatisticsAsync(startDate, endDate, grouping);
        }
    }
}

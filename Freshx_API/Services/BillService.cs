using AutoMapper;
using Freshx_API.Dtos.Payments;
using Freshx_API.Interfaces.Payments;
using Freshx_API.Models;

namespace Freshx_API.Services
{
    public class BillService : IBillService
    {
        private readonly IBillRepository _billRepository;
        private readonly IMapper _mapper;

        public BillService(IBillRepository billRepository, IMapper mapper)
        {
            _billRepository = billRepository;
            _mapper = mapper;
        }

        public async Task<BillDto> CreateBillAsync(BillDto billDto)
        {
            var bill = _mapper.Map<Bill>(billDto);
            var createdBill = await _billRepository.AddBillAsync(bill);
            return _mapper.Map<BillDto>(createdBill);
        }

        public async Task<BillDto> GetBillAsync(int billId)
        {
            var bill = await _billRepository.GetBillByIdAsync(billId);
            Console.WriteLine(bill);
            return _mapper.Map<BillDto>(bill);
        }

        public async Task AddPaymentAsync(PaymentDto paymentDto)
        {
            var bill = await _billRepository.GetBillByIdAsync(paymentDto.BillId);
            if (bill == null) throw new Exception("Bill not found");

            var payment = new Payment
            {
                BillId = paymentDto.BillId,
                AmountPaid = paymentDto.AmountPaid,
                PaymentMethod = paymentDto.PaymentMethod,
                PaymentDate = DateTime.Now
            };

            bill.Payments.Add(payment);
            if (paymentDto.AmountPaid >= bill.TotalAmount)
            {
                bill.PaymentStatus = "Paid";
            }

            await _billRepository.UpdateBillAsync(bill);
        }
    }
}

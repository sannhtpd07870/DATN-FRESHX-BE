using Freshx_API.Interfaces.Payments;
using Freshx_API.Models;
using Microsoft.EntityFrameworkCore;


namespace Freshx_API.Repository
{
    public class BillingRepository : IBillingRepository
    {
        private readonly FreshxDBContext _context;

        public BillingRepository(FreshxDBContext context)
        {
            _context = context;
        }

        public async Task<Bill> AddBillAsync(Bill bill)
        {
            await _context.Bills.AddAsync(bill);
            await _context.SaveChangesAsync();
            return bill;
        }

        public async Task<Bill> GetBillByIdAsync(int billId)
        {
            return await _context.Bills
                .Include(b => b.BillDetails) 
                .Include(b => b.Payments)   
                .FirstOrDefaultAsync(b => b.BillId == billId);
        }

        public async Task<IEnumerable<Bill>> GetAllBillsAsync()
        {
            return await _context.Bills
                .Include(b => b.BillDetails) 
                .Include(b => b.Payments)    
                .ToListAsync();
        }

        public async Task AddPaymentAsync(Payment payment)
        {
            await _context.Payments.AddAsync(payment);
            await _context.SaveChangesAsync();
        }

        public async Task<Bill> UpdateAsync(Bill bill)
        {
            _context.Bills.Update(bill);
            await _context.SaveChangesAsync();
            return bill;
        }

        public async Task<Bill> DeleteAsync(Bill bill)
        {
            _context.Bills.Remove(bill);
            await _context.SaveChangesAsync();
            return bill;
        }

        public async Task<Bill> GetBillWithDetailsAsync(int billId)
        {
            return await _context.Bills
                .Include(b => b.BillDetails)  // Bao gồm chi tiết hóa đơn
                .ThenInclude(bd => bd.ServiceCatalog)  // Bao gồm thông tin dịch vụ
                .Include(b => b.Payments)  // Bao gồm thông tin thanh toán
                .Include(b => b.Reception)  // Bao gồm thông tin bệnh nhân
                .FirstOrDefaultAsync(b => b.BillId == billId);
        }

        public async Task<IEnumerable<object>> GetStatisticsAsync(DateTime startDate, DateTime endDate, string grouping)
        {
            var rawData = await _context.Bills
                .Where(b => b.CreatedDate >= startDate && b.CreatedDate <= endDate)
                .Select(b => new
                {
                    b.CreatedDate,
                    Subtotal = b.BillDetails.Sum(d => (decimal?)d.Subtotal) ?? 0,
                    AmountPaid = b.Payments.Sum(p => (decimal?)p.AmountPaid) ?? 0,
                    Year = b.CreatedDate.Year,
                    Week = (int)Math.Floor(EF.Functions.DateDiffDay(
                        startDate, b.CreatedDate) / 7.0) + 1
                })
                .ToListAsync();

            var groupedData = grouping switch
            {
                "week" => rawData.GroupBy(b => new { b.Year, b.Week })
                    .Select(g => new
                    {
                        Group = $"Week {g.Key.Week}, Year {g.Key.Year}",
                        TotalSubtotal = g.Sum(b => b.Subtotal),
                        TotalAmountPaid = g.Sum(b => b.AmountPaid)
                    }),

                "month" => rawData.GroupBy(b => new { b.CreatedDate.Year, b.CreatedDate.Month })
                    .Select(g => new
                    {
                        Group = $"{g.Key.Month}/{g.Key.Year}",
                        TotalSubtotal = g.Sum(b => b.Subtotal),
                        TotalAmountPaid = g.Sum(b => b.AmountPaid)
                    }),

                "year" => rawData.GroupBy(b => b.CreatedDate.Year)
                    .Select(g => new
                    {
                        Group = $"Year {g.Key}",
                        TotalSubtotal = g.Sum(b => b.Subtotal),
                        TotalAmountPaid = g.Sum(b => b.AmountPaid)
                    }),

                _ => throw new ArgumentException("Invalid grouping type")
            };

            return groupedData;
        }

    }
}

using Freshx_API.Interfaces.Payments;
using Freshx_API.Models;
using Microsoft.EntityFrameworkCore;


namespace Freshx_API.Repository.Payments
{
    public class BillRepository : IBillRepository
    {
        private readonly  FreshxDBContext _context;

        public BillRepository(FreshxDBContext context)
        {
            _context = context;
        }

        public async Task<Bill> AddBillAsync(Bill bill)
        {
            _context.Bills.Add(bill);
            await _context.SaveChangesAsync();
            return bill;
        }

        public async Task<Bill> GetBillByIdAsync(int billId)
        {
            return await _context.Bills
                .Include(b => b.BillDetails)
                .FirstOrDefaultAsync(b => b.BillId == billId);
        }

        public async Task UpdateBillAsync(Bill bill)
        {
            _context.Bills.Update(bill);
            await _context.SaveChangesAsync();
        }
    }

}

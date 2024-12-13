using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Freshx_API.Models;

public class DrugTypeRepository : IDrugTypeRepository
{
    private readonly FreshxDBContext _context;

    public DrugTypeRepository(FreshxDBContext context)
    {
        _context = context;
    }

    public async Task<List< DrugType?>> GetDrugTypeAsync()
    {
        return await _context.DrugTypes.ToListAsync();
    }
    public async Task<DrugType?> GetDrugTypeByIdAsync(int id)
    {
        return await _context.DrugTypes.FirstOrDefaultAsync(d => d.DrugTypeId == id);
    }

    public async Task<DrugType> CreateDrugTypeAsync(DrugType drugType)
    {
        _context.DrugTypes.Add(drugType);
        await _context.SaveChangesAsync();
        return drugType;
    }

    public async Task<DrugType?> UpdateDrugTypeAsync(DrugType drugType)
    {
        _context.DrugTypes.Update(drugType);
        await _context.SaveChangesAsync();
        return drugType;
    }

    public async Task<bool> DeleteDrugTypeAsync(int id)
    {
        var drugType = await GetDrugTypeByIdAsync(id);
        if (drugType == null) return false;

        _context.DrugTypes.Remove(drugType);
        await _context.SaveChangesAsync();
        return true;
    }
}

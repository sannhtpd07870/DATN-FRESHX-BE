using AutoMapper;
using Freshx_API.Dtos.MedicalHistory;
using Freshx_API.Interfaces;
using Freshx_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class MedicalHistoryService
{
    private readonly FreshxDBContext _context;
    private readonly IMapper _mapper;

    public MedicalHistoryService(FreshxDBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // Lấy tất cả các hồ sơ bệnh án từ cơ sở dữ liệu
    public async Task<IEnumerable<MedicalHistoryDto>> GetAllAsync(string? searchKeyword = null)
    {
        // Create the queryable for MedicalHistory table
        var query = _context.MedicalHistorys.AsQueryable();

        // If searchKeyword is provided, filter based on some fields (e.g., Condition, Treatment, etc.)
        if (!string.IsNullOrEmpty(searchKeyword))
        {
            query = query.Where(m => m.Condition.Contains(searchKeyword) || m.Treatment.Contains(searchKeyword));
        }

        // Get the filtered or all records and map to DTOs
        var medicalHistories = await query.ToListAsync();

        return _mapper.Map<IEnumerable<MedicalHistoryDto>>(medicalHistories);
    }

    // Lấy hồ sơ bệnh án theo ID
    public async Task<MedicalHistoryDto?> GetByIdAsync(int id)
    {
        var medicalHistory = await _context.MedicalHistorys
            .FirstOrDefaultAsync(m => m.Id == id);

        if (medicalHistory == null)
        {
            return null;
        }

        return _mapper.Map<MedicalHistoryDto>(medicalHistory);
    }

    // Tạo mới hồ sơ bệnh án
    public async Task<MedicalHistoryDto> CreateAsync(MedicalHistoryCreateUpdateDto dto)
    {
        // Kiểm tra xem bệnh nhân có tồn tại trong cơ sở dữ liệu không
        var patient = await _context.Patients.FirstOrDefaultAsync(p => p.PatientId == dto.PatientId);
        if (patient == null)
        {
            throw new KeyNotFoundException("Bệnh nhân không tồn tại.");
        }

        // Map DTO sang entity MedicalHistory
        var entity = _mapper.Map<MedicalHistory>(dto);

        // Thêm vào context và lưu thay đổi
        _context.MedicalHistorys.Add(entity);
        await _context.SaveChangesAsync();

        // Trả về MedicalHistoryDto sau khi đã lưu
        return _mapper.Map<MedicalHistoryDto>(entity);
    }


    // Cập nhật hồ sơ bệnh án
    public async Task<MedicalHistoryDto> UpdateAsync(int id, MedicalHistoryCreateUpdateDto dto)
    {
        var entity = await _context.MedicalHistorys.FindAsync(id);
        if (entity == null)
        {
            throw new KeyNotFoundException("Medical history not found.");
        }

        _mapper.Map(dto, entity);
        await _context.SaveChangesAsync();

        return _mapper.Map<MedicalHistoryDto>(entity);
    }

    // Xóa hồ sơ bệnh án
    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.MedicalHistorys.FindAsync(id);
        if (entity != null)
        {
            _context.MedicalHistorys.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        return false; // Return false if the entity doesn't exist
    }
}

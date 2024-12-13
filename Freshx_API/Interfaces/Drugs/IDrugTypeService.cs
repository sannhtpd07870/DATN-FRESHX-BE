using Freshx_API.Dtos.Drugs;

public interface IDrugTypeService
{
    Task<List<DrugTypeDto?>> GetDrugTypeAsync();
    Task<DrugTypeDto?> GetDrugTypeByIdAsync(int id);
    Task<DrugTypeDto> CreateDrugTypeAsync(DrugTypeCreateDto createDto);
    Task<DrugTypeDto?> UpdateDrugTypeAsync(int id, DrugTypeUpdateDto updateDto);
    Task<bool> DeleteDrugTypeAsync(int id);
}

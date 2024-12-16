using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Freshx_API.Models;
using Freshx_API.Services.CommonServices;
using Freshx_API.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Net;
using Freshx_API.Dtos.CommonDtos;
using Freshx_API.Interfaces;

namespace Freshx_API.Services
{
    public class DrugCatalogService : IDrugCatalogService
    {
        private readonly FreshxDBContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IDrugCatalogRepository _drugcatalogRepository;
        public DrugCatalogService(FreshxDBContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IDrugCatalogRepository drugcatalogRepository)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _drugcatalogRepository = drugcatalogRepository;
        }

        public async Task<ApiResponse<DrugCatalogDto>> GetDrugCatalogById(int id)
        {
            var drugCatalog = await _context.DrugCatalogs.FindAsync(id);

            if (drugCatalog == null)
            {
                return ResponseFactory.Error<DrugCatalogDto>(_httpContextAccessor.HttpContext!.Request.Path, "Drug catalog not found", StatusCodes.Status404NotFound);
            }

            var drugCatalogDto = _mapper.Map<DrugCatalogDto>(drugCatalog);

            return ResponseFactory.Success(_httpContextAccessor.HttpContext!.Request.Path, drugCatalogDto, "Retrieved successfully", StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<IEnumerable<DrugCatalogDto>>> GetAllDrugCatalogs()
        {
            var drugCatalogs = await _drugcatalogRepository.GetAllAsync();
            var drugCatalogDtos = _mapper.Map<IEnumerable<DrugCatalogDto>>(drugCatalogs);

            return ResponseFactory.Success(_httpContextAccessor.HttpContext!.Request.Path, drugCatalogDtos, "All drug catalogs retrieved successfully", StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<bool>> CreateDrugCatalog(CreateDrugCatalogDto drugCatalogDto)
        {
            var drugCatalog = _mapper.Map<DrugCatalog>(drugCatalogDto);
            _context.DrugCatalogs.Add(drugCatalog);
            await _context.SaveChangesAsync();

            return ResponseFactory.Success(_httpContextAccessor.HttpContext!.Request.Path, true, "Drug catalog created successfully", StatusCodes.Status201Created);
        }

        public async Task<ApiResponse<bool>> UpdateDrugCatalog(int id, DrugCatalogDto drugCatalogDto)
        {
            var existingDrugCatalog = await _context.DrugCatalogs.FindAsync(id);
            if (existingDrugCatalog == null)
            {
                return ResponseFactory.Error<bool>(_httpContextAccessor.HttpContext!.Request.Path, "Drug catalog not found", StatusCodes.Status404NotFound);
            }

            _mapper.Map(drugCatalogDto, existingDrugCatalog);
            await _context.SaveChangesAsync();

            return ResponseFactory.Success(_httpContextAccessor.HttpContext!.Request.Path, true, "Drug catalog updated successfully", StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<bool>> DeleteDrugCatalog(int id)
        {
            var existingDrugCatalog = await _context.DrugCatalogs.FindAsync(id);
            if (existingDrugCatalog == null)
            {
                return ResponseFactory.Error<bool>(_httpContextAccessor.HttpContext!.Request.Path, "Drug catalog not found", StatusCodes.Status404NotFound);
            }

            _context.DrugCatalogs.Remove(existingDrugCatalog);
            await _context.SaveChangesAsync();

            return ResponseFactory.Success(_httpContextAccessor.HttpContext!.Request.Path, true, "Drug catalog deleted successfully", StatusCodes.Status200OK);
        }
    }
}
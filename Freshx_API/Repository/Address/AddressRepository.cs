using Freshx_API.Dtos;
using Freshx_API.Dtos.CommonDtos;
using Freshx_API.Interfaces;
using Freshx_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Freshx_API.Repository.Address
{
    public class AddressRepository : IAddressRepository
    {
        private readonly FreshxDBContext _context;

        public AddressRepository(FreshxDBContext context)
        {
            _context = context;
        }

        public async Task<List<Province>> GetAllProvincesAsync()
        {
            return await _context.Set<Province>().ToListAsync();
        }

        public async Task<Province> GetProvinceByCodeAsync(string code)
        {
          
            return await _context.Set<Province>().FirstOrDefaultAsync(p => p.Code == code);
        }

        public async Task<List<District>> GetDistrictsByProvinceCodeAsync(string? provinceCode)
        {
            if (provinceCode == null) { 
            return await _context.Districts.ToListAsync();
            }
            return await _context.Set<District>().Where(d => d.ProvinceCode == provinceCode).ToListAsync();
        }

        public async Task<District> GetDistrictByCodeAsync(string code)
        {
            return await _context.Set<District>().FirstOrDefaultAsync(d => d.Code == code);
        }

        public async Task<List<Ward>> GetWardsByDistrictCodeAsync(string? districtCode)
        {
            if (districtCode== null) {
                return await _context.Wards.ToListAsync();
            }
            return await _context.Set<Ward>().Where(w => w.DistrictCode == districtCode).ToListAsync();
        }

        public async Task<Ward> GetWardByCodeAsync(string code)
        {
            return await _context.Set<Ward>().FirstOrDefaultAsync(w => w.Code == code);
        }

        public async Task<List<AddressSearchResult>> SearchAddress(Parameters request)
        {
            // Tách các từ khóa tìm kiếm và chuẩn hóa
            var searchTerms = request.SearchTerm
                .Split(',')
                .Select(term => term.Trim().ToLower())
                .Where(term => !string.IsNullOrEmpty(term))
                .ToList();

            if (!searchTerms.Any())
                return new List<AddressSearchResult>();

            // Tạo query cơ bản với joins
            var query = from ward in _context.Set<Ward>()
                        join district in _context.Set<District>()
                            on ward.DistrictCode equals district.Code
                        join province in _context.Set<Province>()
                            on district.ProvinceCode equals province.Code
                        select new
                        {
                            Ward = ward,
                            District = district,
                            Province = province
                        };

            // Áp dụng điều kiện tìm kiếm cho từng term
            foreach (var term in searchTerms)
            {
                query = query.Where(x =>
                    x.Ward.Name.ToLower().Contains(term) ||
                    x.Ward.FullName.ToLower().Contains(term) ||
                    x.District.Name.ToLower().Contains(term) ||
                    x.District.FullName.ToLower().Contains(term) ||
                    x.Province.Name.ToLower().Contains(term) ||
                    x.Province.FullName.ToLower().Contains(term)
                );
            }

            // Chuyển đổi kết quả về dạng đơn giản
            var results = await query
                .Take(10)
                .Select(x => new AddressSearchResult
                {
                    Text = $"{x.Ward.Name}, {x.District.Name}, {x.Province.Name}",
                    AddressDetails = new AddressDetails
                    {
                        WardCode = x.Ward.Code,
                        WardName = x.Ward.Name,
                        DistrictCode = x.District.Code,
                        DistrictName = x.District.Name,
                        ProvinceCode = x.Province.Code,
                        ProvinceName = x.Province.Name
                    }
                })
                .ToListAsync();

            return results;
        }

    }

}

﻿using Freshx_API.Dtos;
using Freshx_API.Dtos.CommonDtos;

namespace Freshx_API.Interfaces
{
    public interface IAddressService
    {
        Task<List<ProvinceDto>> GetAllProvincesAsync();
        Task<ProvinceDto> GetProvinceByCodeAsync(string code);
        Task<List<DistrictDto>> GetDistrictsByProvinceCodeAsync(string? provinceCode);
        Task<DistrictDto> GetDistrictByCodeAsync(string code);
        Task<List<WardDto>> GetWardsByDistrictCodeAsync(string? districtCode);
        Task<WardDto> GetWardByCodeAsync(string code);
        Task<List<AddressSearchResult>> SearchAddress(Parameters request);
    }

}

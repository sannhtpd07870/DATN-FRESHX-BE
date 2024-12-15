using AutoMapper;
using Freshx_API.Dtos;
using Freshx_API.Dtos.Auth.Account;
using Freshx_API.Dtos.Auth.Role;
using Freshx_API.Dtos.DepartmenTypeDtos;
using Freshx_API.Dtos.Drugs;
using Freshx_API.Models;
using Microsoft.AspNetCore.Identity;

namespace Freshx_API.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Savefile, FileDto>().ReverseMap();
            CreateMap<IdentityRole, RoleResponse>();
            CreateMap<AppUser, RegisterResponse>();
            CreateMap<DrugCatalog, DrugCatalogDto>();
            CreateMap<CreateDrugCatalogDto, DrugCatalog>();
            CreateMap<UpdateDrugCatalogDto, DrugCatalog>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<DrugType, DrugTypeDto>();
            CreateMap<DrugTypeCreateDto, DrugType>();
            CreateMap<DrugTypeUpdateDto, DrugType>();

            // Mapping từ Model sang DTO
            CreateMap<DepartmentType, DepartmentTypeDto>();
            CreateMap<DepartmentType, DepartmentTypeDetailDto>();

            // Mapping từ DTO sang Model khi tạo hoặc cập nhật
            CreateMap<DepartmentTypeCreateUpdateDto, DepartmentType>();
        }
    }
}

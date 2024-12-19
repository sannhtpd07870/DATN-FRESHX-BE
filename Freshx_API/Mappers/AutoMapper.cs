using AutoMapper;
using Freshx_API.Dtos;
using Freshx_API.Dtos.Auth.Account;
using Freshx_API.Dtos.Auth.Role;
using Freshx_API.Dtos.DepartmenTypeDtos;

using Freshx_API.Dtos.Doctor;

using Freshx_API.Dtos.DepartmentDtos;

using Freshx_API.Dtos.Drugs;
using Freshx_API.Models;
using Microsoft.AspNetCore.Identity;
using Freshx_API.Dtos.InventoryType;
using Freshx_API.Dtos.Pharmacy;
using Freshx_API.Dtos.Receptionist;
using Freshx_API.Dtos.ServiceGroup;
using Freshx_API.Dtos.ServiceCatalog;
using Freshx_API.Dtos.UnitOfMeasure;

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



            // Doctor Mappings
            CreateMap<Doctor, DoctorDto>();
            CreateMap<Doctor, DoctorDetailDto>();   
            CreateMap<DoctorCreateUpdateDto, Doctor>();

            // Mapping từ Model Department sang DTO
            CreateMap<Department, DepartmentDto>();
            CreateMap<Department, DepartmentDetailDto>();


            // Mapping từ DTO sang Model Department khi tạo hoặc cập nhật
            CreateMap<DepartmentCreateUpdateDto, Department>()

                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // Entity to DTO
            CreateMap<InventoryType, InventoryTypeDto>();

            // DTO to Entity
            CreateMap<InventoryTypeCreateUpdateDto, InventoryType>();

            // Ánh xạ Pharmacy sang PharmacyDto
            CreateMap<Pharmacy, PharmacyDto>();

            // Ánh xạ PharmacyCreateUpdateDto sang Pharmacy (dùng cho tạo mới hoặc cập nhật)
            CreateMap<PharmacyCreateUpdateDto, Pharmacy>();

            // Ánh xạ Pharmacy sang PharmacyDetailDto (chi tiết của nhà thuốc)
            CreateMap<Pharmacy, PharmacyDetailDto>();



            // Ánh xạ từ model Receptionist sang DTO hiển thị thông tin cơ bản
            CreateMap<Receptionist, ReceptionistDto>();

            // Ánh xạ từ DTO tạo mới/cập nhật sang model Receptionist
            CreateMap<ReceptionistCreateUpdateDto, Receptionist>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));


            // Mapping từ Model ServiceGroup sang DTO cơ bản
            CreateMap<ServiceGroup, ServiceGroupDto>();

            // Mapping từ Model ServiceGroup sang DTO chi tiết
            CreateMap<ServiceGroup, ServiceGroupDetailDto>();

            // Mapping từ DTO ServiceGroupCreateUpdateDto sang Model ServiceGroup khi tạo hoặc cập nhật
            CreateMap<ServiceGroupCreateUpdateDto, ServiceGroup>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // Ánh xạ từ model Receptionist sang DTO hiển thị chi tiết thông tin
            CreateMap<Receptionist, ReceptionistDetailDto>();

            // ServiceCatalog Mappings
            CreateMap<ServiceCatalog, ServiceCatalogDto>();
            CreateMap<ServiceCatalog, ServiceCatalogDetailDto>();
            CreateMap<ServiceCatalogCreateUpdateDto, ServiceCatalog>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // Map UnitOfMeasure -> UnitOfMeasureDetailDto
            CreateMap<UnitOfMeasure, UnitOfMeasureDetailDto>();

            // Map UnitOfMeasureCreateUpdateDto -> UnitOfMeasure
            CreateMap<UnitOfMeasureCreateUpdateDto, UnitOfMeasure>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}

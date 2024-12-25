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
using Freshx_API.Dtos.ServiceGroup;
using Freshx_API.Dtos.ServiceCatalog;
using Freshx_API.Dtos.UnitOfMeasure;
using Freshx_API.Dtos.Supplier;
using System.Diagnostics.Metrics;
using Freshx_API.Dtos.Country;
using Freshx_API.Dtos.DrugCatalog;
using Freshx_API.Dtos.Payments;
using Freshx_API.Dtos.UserAccount;

namespace Freshx_API.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Savefile, FileDto>().ReverseMap();
            CreateMap<IdentityRole, RoleResponse>();
            CreateMap<AppUser, RegisterResponse>();
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



            // Mapping từ Model ServiceGroup sang DTO cơ bản
            CreateMap<ServiceGroup, ServiceGroupDto>();

            // Mapping từ Model ServiceGroup sang DTO chi tiết
            CreateMap<ServiceGroup, ServiceGroupDetailDto>();

            // Mapping từ DTO ServiceGroupCreateUpdateDto sang Model ServiceGroup khi tạo hoặc cập nhật
            CreateMap<ServiceGroupCreateUpdateDto, ServiceGroup>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // ServiceCatalog Mappings
            CreateMap<ServiceCatalog, ServiceCatalogDto>();
            CreateMap<ServiceCatalog, ServiceCatalogDetailDto>();
            CreateMap<ServiceCatalogCreateUpdateDto, ServiceCatalog>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));


            //CreateMap<Patient, PatientDto>();
            CreateMap<Reception, CreateReceptionDto>();
            

            // Map UnitOfMeasure -> UnitOfMeasureDetailDto
            CreateMap<UnitOfMeasure, UnitOfMeasureDetailDto>();

            // Map UnitOfMeasureCreateUpdateDto -> UnitOfMeasure
            CreateMap<UnitOfMeasureCreateUpdateDto, UnitOfMeasure>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // Map Supplier -> SupplierDetailDto
            CreateMap<Supplier, SupplierDetailDto>();

            // Map SupplierCreateUpdateDto -> Supplier
            CreateMap<SupplierCreateUpdateDto, Supplier>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // Map country -> CountryDto
            CreateMap<Country, CountryDto>();

            // Map CountryCreateUpdateDto -> Country
            CreateMap<CountryCreateUpdateDto, Country>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));


            // Map DrugCatalog -> DrugCatalogDetailDto
            CreateMap<DrugCatalog, DrugCatalogDetailDto>();

            // Map DrugCatalogCreateUpdateDto -> DrugCatalog
            CreateMap<DrugCatalogCreateUpdateDto, DrugCatalog>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        
            //Địa chỉ 
            CreateMap<Province, ProvinceDto>();
            CreateMap<District, DistrictDto>();
            CreateMap<Ward, WardDto>();

            // Mapping Bill to BillDto
            CreateMap<Bill, BillDto>()
                .ForMember(dest => dest.BillDetails, opt => opt.MapFrom(src => src.BillDetails));

            // Mapping BillDto to Bill
            CreateMap<BillDto, Bill>()
                .ForMember(dest => dest.BillDetails, opt => opt.MapFrom(src => src.BillDetails));

            // Mapping BillDetail to BillDetailDto
            CreateMap<BillDetail, BillDetailDto>().ReverseMap();

            //medical service reqest
            CreateMap<MedicalServiceRequest, MedicalServiceRequestDto>().ReverseMap();

            // tiếp nhận
            CreateMap<Reception, CreateReceptionDto>()
          .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient != null ? src.Patient.Name : null))
          .ForMember(dest => dest.ReceptionistName, opt => opt.MapFrom(src => src.Receptionist != null ))
          .ForMember(dest => dest.AssignedDoctorName, opt => opt.MapFrom(src => src.AssignedDoctor != null ? src.AssignedDoctor.Name : null))
          .ReverseMap();
    

            CreateMap<UpdateMedicalServiceRequestDTO, MedicalServiceRequest>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<AppUser, UserResponse>().ReverseMap();
        }
    }
}

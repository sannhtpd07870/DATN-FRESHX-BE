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
using Freshx_API.Dtos.Patient;
using Freshx_API.Dtos.ExamineDtos;

namespace Freshx_API.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Savefile, FileDto>().ReverseMap();
            CreateMap<IdentityRole, RoleResponse>();
            CreateMap<AppUser, RegisterResponse>();
            CreateMap<DrugType, DrugTypeDto>().ReverseMap();
            CreateMap<DrugTypeCreateDto, DrugType>();
            CreateMap<DrugTypeUpdateDto, DrugType>();

            // Mapping từ Model sang DTO
            CreateMap<DepartmentType, DepartmentTypeDto>();
            CreateMap<DepartmentType, DepartmentTypeDetailDto>();

            // Mapping từ DTO sang Model khi tạo hoặc cập nhật
            CreateMap<DepartmentTypeCreateUpdateDto, DepartmentType>();

            // Doctor Mappings
            CreateMap<Doctor, DoctorDto>().ReverseMap();
            CreateMap<Doctor, DoctorDetailDto>();
            CreateMap<DoctorCreateUpdateDto, Doctor>();

            // Mapping từ Model Department sang DTO
            CreateMap<Department, DepartmentDto>().ReverseMap();
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
            CreateMap<ServiceCatalog, ServiceCatalogDto>().ReverseMap();
            CreateMap<ServiceCatalog, ServiceCatalogDetailDto>().ReverseMap();
            CreateMap<ServiceCatalogCreateUpdateDto, ServiceCatalog>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));


            //CreateMap<Patient, PatientDto>();
            CreateMap<Reception, CreateReceptionDto>().ReverseMap();
            

            // Map UnitOfMeasure -> UnitOfMeasureDetailDto
            CreateMap<UnitOfMeasure, UnitOfMeasureDetailDto>().ReverseMap();

            // Map UnitOfMeasureCreateUpdateDto -> UnitOfMeasure
            CreateMap<UnitOfMeasureCreateUpdateDto, UnitOfMeasure>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // Map Supplier -> SupplierDetailDto
            CreateMap<Supplier, SupplierDetailDto>().ReverseMap();

            // Map SupplierCreateUpdateDto -> Supplier
            CreateMap<SupplierCreateUpdateDto, Supplier>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // Map country -> CountryDto
            CreateMap<Country, CountryDto>().ReverseMap();

            // Map CountryCreateUpdateDto -> Country
            CreateMap<CountryCreateUpdateDto, Country>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));


            // Map DrugCatalog -> DrugCatalogDetailDto
            CreateMap<DrugCatalog, DrugCatalogDetailDto>();

            // Map DrugCatalogCreateUpdateDto -> DrugCatalog
            CreateMap<DrugCatalogCreateUpdateDto, DrugCatalog>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        
            //Địa chỉ 
            CreateMap<Province, ProvinceDto>().ReverseMap();
            CreateMap<District, DistrictDto>().ReverseMap();
            CreateMap<Ward, WardDto>().ReverseMap();

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
            CreateMap<MedicalServiceRequest, CreateMedicalServiceRequestDto>().ReverseMap();
            // tiếp nhận
            CreateMap<Reception, CreateReceptionDto>().ReverseMap();
            CreateMap<ReceptionDto, Reception>().ReverseMap();

            //create-update patient
            CreateMap<AddingPatientRequest, UpdatingPatientRequest>().ReverseMap();

            //Examine khám bệnh
            CreateMap<Examine, ExamineResponseDto>().ReverseMap();
            CreateMap<ExamineRequestDto, Examine>().ReverseMap();

            CreateMap<AppUser, UserResponse>().ReverseMap();

            //Mapping Patient Model to PatientResponseDto
            CreateMap<Patient,PatientResponseDto>().ReverseMap();
        }
    }
}

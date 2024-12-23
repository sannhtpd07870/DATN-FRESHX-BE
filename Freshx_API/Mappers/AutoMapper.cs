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
using Freshx_API.DTOs;
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


            // Invoice Mappings
            CreateMap<Invoice, InvoiceDto>();
            CreateMap<CreateInvoiceDto, Invoice>();
            CreateMap<UpdateInvoiceDto, Invoice>();

            CreateMap<Patient, PatientDto>();
            CreateMap<Reception, ReceptionDto>();
            CreateMap<ICDCatalog, ICDCatalogDto>();

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

            //Map DocumentPurposeDto
            // Entity to DTO
            CreateMap<DocumentPurpose, DocumentPurposeDto>();

            // DTO to Entity
            CreateMap<DocumentPurpose, DocumentPurposeDto>();
            CreateMap<DocumentPurposeDto, DocumentPurpose>();
            CreateMap<CreateDocumentPurposeDto, DocumentPurpose>(); // If CreateDocumentPurposeDto is used

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

            //
            CreateMap<AppUser,UserResponse>().ReverseMap();
        }
    }
}

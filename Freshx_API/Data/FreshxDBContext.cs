using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Freshx_API.Models;

public partial class FreshxDBContext : IdentityDbContext<AppUser,IdentityRole,string>
{
    public FreshxDBContext(DbContextOptions<FreshxDBContext> options)
        : base(options)
    {
    }


    //public DbSet<Savefile> Savefiles { get; set; }
    //public DbSet<AdministrativeUnit> AdministrativeUnits { get; set; }
    //public DbSet<Appointment> Appointments { get; set; }
    //public DbSet<AppUser> AppUsers { get; set; }
    //public DbSet<InventoryType> InventoryTypes { get; set; }
    //public DbSet<DepartmentType> DepartmentTypes { get; set; }
    //public DbSet<DrugType> DrugTypes { get; set; }
    //public DbSet< ICDCatalog>  ICDCatalogs { get; set; }
    //public DbSet<ServiceGroup> ServiceGroups { get; set; }
    //public DbSet<DiseaseGroup> DiseaseGroups { get; set; }
    //public DbSet<Country> Countries { get; set; }
    //public DbSet<ConclusionDictionary> ConclusionDictionaries { get; set; }
    //public DbSet<ExaminationConfirmation> ExaminationConfirmations { get; set; }
    //public DbSet<Report> Reports { get; set; }
    //public DbSet<ReportParameter> ReportParameters { get; set; }
    //public DbSet<LabTestFile> LabTestFiles { get; set; }
    //public DbSet<ZaloUser> ZaloUsers { get; set; }
    //public DbSet<Reception> Receptions { get; set; }
    //public DbSet<Invoice> Invoices { get; set; }
    //public DbSet<ServiceCatalog> ServiceCatalogs { get; set; }
    //public DbSet<PriceType> PriceTypes { get; set; }
    //public DbSet<TypeOfControlInput> TypeOfControlInputs { get; set; }

   
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<AppUser> AppUsers { get; set; }  // Or perhaps a more descriptive name like "ApplicationUsers"
    public DbSet<ConclusionDictionary> ConclusionDictionaries { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<DepartmentType> DepartmentTypes { get; set; }
    public DbSet<DiagnosisDictionary> DiagnosisDictionaries { get; set; }
    public DbSet<DiagnosticImagingResult> DiagnosticImagingResults { get; set; }
    public DbSet<DiagnosticImagingResultImage> DiagnosticImagingResultImages { get; set; }
    public DbSet<Dictionary> Dictionaries { get; set; }  //  Consider a more specific name if possible. "Dictionary" is very generic.
    public DbSet<DiseaseGroup> DiseaseGroups { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<DoctorsCommonIcd> DoctorsCommonIcds { get; set; } // Consider renaming for clarity
    public DbSet<Document> Documents { get; set; }
    public DbSet<DocumentDetail> DocumentDetails { get; set; }
    public DbSet<DocumentPurpose> DocumentPurposes { get; set; }
    public DbSet<DrugBooking> DrugBookings { get; set; }
    public DbSet<DrugCatalog> DrugCatalogs { get; set; }
    public DbSet<DrugType> DrugTypes { get; set; }
    public DbSet<EinvoiceFile> EinvoiceFiles { get; set; }
    public DbSet<EmailAccount> EmailAccounts { get; set; }
    public DbSet<EmailContent> EmailContents { get; set; }
    public DbSet<EmailContentImage> EmailContentImages { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<ExaminationConfirmation> ExaminationConfirmations { get; set; }
    public DbSet<Hospital> Hospitals { get; set; }
    public DbSet<ICDCatalog> ICDcatalogs { get; set; } // Follow C# capitalization conventions: IcdCatalogs
    public DbSet<Icdchapter> Icdchapters { get; set; } // IcdChapters
    public DbSet<InventoryType> InventoryTypes { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<LabResult> LabResults { get; set; }
    public DbSet<LabTestFile> LabTestFiles { get; set; }
    public DbSet<LoginSession> LoginSessions { get; set; }
    public DbSet<MedicalServiceRequest> MedicalServiceRequests { get; set; }
    public DbSet<Menu> Menus { get; set; }
    public DbSet<MenuPermission> MenuPermissions { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Pharmacy> Pharmacies { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PriceType> PriceTypes { get; set; }
    public DbSet<Reception> Receptions { get; set; }
    public DbSet<Report> Reports { get; set; }
    public DbSet<ReportParameter> ReportParameters { get; set; }
    public DbSet<ReportPermission> ReportPermissions { get; set; }
    public DbSet<Savefile> Savefiles { get; set; } // Consider a more descriptive name
    public DbSet<ServiceCatalog> ServiceCatalogs { get; set; }
    public DbSet<ServiceGroup> ServiceGroups { get; set; }
    public DbSet<ServiceStandardValue> ServiceStandardValues { get; set; }
    public DbSet<Setting> Settings { get; set; } // Consider a more descriptive name
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Technician> Technicians { get; set; }
    public DbSet<TemplatePrescription> TemplatePrescriptions { get; set; }
    public DbSet<TemplatePrescriptionDrugMapping> TemplatePrescriptionDrugMappings { get; set; }
    public DbSet<TypeOfControlInput> TypeOfControlInputs { get; set; } // Consider reviewing the typo: TypeOfControlInput?
    public DbSet<UnitOfMeasure> UnitOfMeasures { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserAction> UserActions { get; set; }
    public DbSet<UserActionByMedicalRecord> UserActionByMedicalRecords { get; set; }
    public DbSet<UserDepartment> UserDepartments { get; set; }
    public DbSet<UserPharmacy> UserPharmacies { get; set; }
    public DbSet<District> Districts { get; set; }
    public DbSet<Province> Provinces { get; set; }
    public DbSet<Ward> Wards { get; set; }
    public DbSet<ZaloUser> ZaloUsers { get; set; }
    public DbSet<ChatMessage> ChatMessages { get; set; }
    public DbSet<Conversation> Conversations { get; set; }
    public DbSet<Receptionist> Receptionists { get; set; }
    public DbSet<Position> Positions { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure foreign keys and relationships

        //  ICDCatalog
        modelBuilder.Entity< ICDCatalog>()
            .HasOne(i => i. ICDCatalogGroup)
            .WithMany()
            .HasForeignKey(i => i. ICDCatalogGroupId)
            .OnDelete(DeleteBehavior.Restrict);

        // ConclusionDictionary
        modelBuilder.Entity<ConclusionDictionary>()
            .HasOne(c => c.ServiceCatalog)
            .WithMany()
            .HasForeignKey(c => c.ServiceCatalogId)
            .OnDelete(DeleteBehavior.Restrict);

        // ExaminationConfirmation
        modelBuilder.Entity<ExaminationConfirmation>()
            .HasOne(e => e.Reception)
            .WithMany()
            .HasForeignKey(e => e.ReceptionId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ExaminationConfirmation>()
            .HasOne(e => e.Invoice)
            .WithMany()
            .HasForeignKey(e => e.MedicalExaminationId)
            .OnDelete(DeleteBehavior.Restrict);

        // ReportParameter
        modelBuilder.Entity<ReportParameter>()
            .HasOne(r => r.Report)
            .WithMany()
            .HasForeignKey(r => r.ReportId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ReportParameter>()
            .HasOne(r => r.TypeOfControlInput)
            .WithMany()
            .HasForeignKey(r => r.TypeOfControlInputId)
            .OnDelete(DeleteBehavior.Restrict);

        // LabTestFile
        modelBuilder.Entity<LabTestFile>()
            .HasOne(l => l.Reception)
            .WithMany()
            .HasForeignKey(l => l.ReceptionId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<LabTestFile>()
            .HasOne(l => l.Patient)
            .WithMany()
            .HasForeignKey(l => l.PatientId)
            .OnDelete(DeleteBehavior.Restrict);

        // ServiceCatalog
        modelBuilder.Entity<ServiceCatalog>()
            .HasOne(s => s.ServiceGroup)
            .WithMany()
            .HasForeignKey(s => s.ServiceGroupId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ServiceCatalog>()
            .HasOne(s => s.ParentService)
            .WithMany()
            .HasForeignKey(s => s.ParentServiceId)
            .OnDelete(DeleteBehavior.Restrict);

        //modelBuilder.Entity<ServiceCatalog>()
        //    .HasOne(s => s.PriceType)
        //    .WithMany()
        //    .HasForeignKey(s => s.PriceTypeId)
        //    .OnDelete(DeleteBehavior.Restrict);
    }
}

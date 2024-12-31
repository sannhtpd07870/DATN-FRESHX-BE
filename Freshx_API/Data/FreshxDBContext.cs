using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Xml;

namespace Freshx_API.Models;

public partial class FreshxDBContext : IdentityDbContext<AppUser, IdentityRole, string>
{
    public FreshxDBContext(DbContextOptions<FreshxDBContext> options)
        : base(options)
    {
    }

    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<ConclusionDictionary> ConclusionDictionaries { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<DepartmentType> DepartmentTypes { get; set; }
    public DbSet<DiagnosisDictionary> DiagnosisDictionaries { get; set; }
    public DbSet<DiagnosticImagingResult> DiagnosticImagingResults { get; set; }
    public DbSet<DiseaseGroup> DiseaseGroups { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<DrugBooking> DrugBookings { get; set; }
    public DbSet<DrugCatalog> DrugCatalogs { get; set; }
    public DbSet<DrugType> DrugTypes { get; set; }
    public DbSet<EmailContent> EmailContents { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Clinic> Hospitals { get; set; }
    public DbSet<ICDCatalog> ICDcatalogs { get; set; }
    public DbSet<Icdchapter> Icdchapters { get; set; }
    public DbSet<InventoryType> InventoryTypes { get; set; }
    public DbSet<Examine> Examines { get; set; }
    public DbSet<LabResult> LabResults { get; set; }
    public DbSet<MedicalServiceRequest> MedicalServiceRequests { get; set; }
    public DbSet<Menu> Menus { get; set; }
    public DbSet<MenuParent> MenuPermissions { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Pharmacy> Pharmacies { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<Reception> Receptions { get; set; }
    public DbSet<Savefile> Savefiles { get; set; }
    public DbSet<ServiceCatalog> ServiceCatalogs { get; set; }
    public DbSet<ServiceGroup> ServiceGroups { get; set; }
    public DbSet<ServiceStandardValue> ServiceStandardValues { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Technician> Technicians { get; set; }
    public DbSet<TemplatePrescription> TemplatePrescriptions { get; set; }
    public DbSet<ServiceTypes> ServiceTypes { get; set; }
    public DbSet<UnitOfMeasure> UnitOfMeasures { get; set; }
    public DbSet<District> Districts { get; set; }
    public DbSet<Province> Provinces { get; set; }
    public DbSet<Ward> Wards { get; set; }

    public DbSet<ChatMessage> ChatMessages { get; set; }
    public DbSet<Conversation> Conversations { get; set; }

    public DbSet<Bill> Bills { get; set; }
    public DbSet<BillDetail> BillDetails { get; set; }
    public DbSet<Payment> Payments { get; set; }

    public DbSet<Position> Positions { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // ICDCatalog
        modelBuilder.Entity<ICDCatalog>()
            .HasOne(i => i.ICDCatalogGroup)
            .WithMany()
            .HasForeignKey(i => i.ICDCatalogGroupId)
            .OnDelete(DeleteBehavior.Restrict);

        // ConclusionDictionary
        modelBuilder.Entity<ConclusionDictionary>()
            .HasOne(c => c.ServiceCatalog)
            .WithMany()
            .HasForeignKey(c => c.ServiceCatalogId)
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

        modelBuilder.Entity<Bill>()
            .HasMany(b => b.BillDetails)
            .WithOne(d => d.Bill)
            .HasForeignKey(d => d.BillId);

        modelBuilder.Entity<Bill>()
            .HasMany(b => b.Payments)
            .WithOne(p => p.Bill)
            .HasForeignKey(p => p.BillId);


        modelBuilder.Entity<LabResult>(b =>
        {
            b.HasKey(e => e.LabResultId);
            b.Property(e => e.LabResultId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<AppUser>()
            .HasOne(u => u.Doctor)
            .WithOne(d => d.AppUser)
            .HasForeignKey<Doctor>(d => d.AccountId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull); // OnDelete cascade or restrict is corrected

        modelBuilder.Entity<AppUser>()
            .HasOne(u => u.Patient)
            .WithOne(p => p.AppUser)
            .HasForeignKey<Patient>(p => p.AccountId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<AppUser>()
            .HasOne(u => u.Technician)
            .WithOne(t => t.AppUser)
            .HasForeignKey<Technician>(t => t.AccountId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<AppUser>()
            .HasOne(u => u.Employee)
            .WithOne(e => e.AppUser)
            .HasForeignKey<Employee>(e => e.AccountId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);

        // DrugCatalog
        modelBuilder.Entity<DrugCatalog>()
            .Property(e => e.CostPrice)
            .HasColumnType("decimal(10,3)");

        modelBuilder.Entity<DrugCatalog>()
            .Property(e => e.QuantityImported)
            .HasColumnType("decimal(10,3)");

        modelBuilder.Entity<DrugCatalog>()
            .Property(e => e.QuantityInStock)
            .HasColumnType("decimal(10,3)");

        modelBuilder.Entity<DrugCatalog>()
            .Property(e => e.UnitPrice)
            .HasColumnType("decimal(10,3)");

        // DrugCatalog relationships
        modelBuilder.Entity<DrugCatalog>()
            .HasOne(d => d.UnitOfMeasure)
            .WithMany(u => u.DrugCatalogs)
            .HasForeignKey(d => d.UnitOfMeasureId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<DrugCatalog>()
            .HasOne(d => d.Manufacturer)
            .WithMany()
            .HasForeignKey(d => d.ManufacturerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<DrugCatalog>()
            .HasOne(d => d.Country)
            .WithMany(u => u.DrugCatalogs)
            .HasForeignKey(d => d.CountryId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<DrugCatalog>()
            .HasOne(d => d.DrugType)
            .WithMany(u => u.DrugCatalogs)
            .HasForeignKey(d => d.DrugTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        // DrugBooking
        modelBuilder.Entity<DrugBooking>()
            .Property(e => e.AfternoonDose)
            .HasColumnType("decimal(10,3)");

        modelBuilder.Entity<DrugBooking>()
            .Property(e => e.DaysOfSupply)
            .HasColumnType("decimal(10,3)");

        modelBuilder.Entity<DrugBooking>()
            .Property(e => e.EveningDose)
            .HasColumnType("decimal(10,3)");

        modelBuilder.Entity<DrugBooking>()
            .Property(e => e.MorningDose)
            .HasColumnType("decimal(10,3)");

        modelBuilder.Entity<DrugBooking>()
            .Property(e => e.NoonDose)
            .HasColumnType("decimal(10,3)");

        modelBuilder.Entity<DrugBooking>()
            .Property(e => e.Quantity)
            .HasColumnType("decimal(10,3)");

        modelBuilder.Entity<DrugBooking>()
            .Property(e => e.TotalAmount)
            .HasColumnType("decimal(10,3)");

        modelBuilder.Entity<DrugBooking>()
            .Property(e => e.UnitPrice)
            .HasColumnType("decimal(10,3)");

        // Configure precision for decimal properties
        modelBuilder.Entity<MedicalServiceRequest>()
            .Property(m => m.ServiceTotalAmount)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<UnitOfMeasure>()
            .Property(u => u.ConversionValue)
            .HasColumnType("decimal(18,4)");
    }
}

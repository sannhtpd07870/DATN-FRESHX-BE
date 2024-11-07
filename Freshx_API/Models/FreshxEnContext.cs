using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace convert_model.Models;

public partial class FreshxEnContext : DbContext
{
    public FreshxEnContext()
    {
    }

    public FreshxEnContext(DbContextOptions<FreshxEnContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdministrativeUnit> AdministrativeUnits { get; set; }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<ConclusionDictionary> ConclusionDictionaries { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<DepartmentType> DepartmentTypes { get; set; }

    public virtual DbSet<DiagnosisDictionary> DiagnosisDictionaries { get; set; }

    public virtual DbSet<DiagnosticImagingResult> DiagnosticImagingResults { get; set; }

    public virtual DbSet<DiagnosticImagingResultImage> DiagnosticImagingResultImages { get; set; }

    public virtual DbSet<Dictionary> Dictionaries { get; set; }

    public virtual DbSet<DiseaseGroup> DiseaseGroups { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<DoctorsCommonIcd> DoctorsCommonIcds { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<DocumentDetail> DocumentDetails { get; set; }

    public virtual DbSet<DocumentPurpose> DocumentPurposes { get; set; }

    public virtual DbSet<DrugBooking> DrugBookings { get; set; }

    public virtual DbSet<DrugCatalog> DrugCatalogs { get; set; }

    public virtual DbSet<DrugType> DrugTypes { get; set; }

    public virtual DbSet<EinvoiceFile> EinvoiceFiles { get; set; }

    public virtual DbSet<EmailAccount> EmailAccounts { get; set; }

    public virtual DbSet<EmailContent> EmailContents { get; set; }

    public virtual DbSet<EmailContentImage> EmailContentImages { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<ExaminationConfirmation> ExaminationConfirmations { get; set; }

    public virtual DbSet<Hospital> Hospitals { get; set; }

    public virtual DbSet<Icdcatalog> Icdcatalogs { get; set; }

    public virtual DbSet<Icdchapter> Icdchapters { get; set; }

    public virtual DbSet<InventoryType> InventoryTypes { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<LabResult> LabResults { get; set; }

    public virtual DbSet<LabTestFile> LabTestFiles { get; set; }

    public virtual DbSet<LoginSession> LoginSessions { get; set; }

    public virtual DbSet<MedicalServiceRequest> MedicalServiceRequests { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<MenuPermission> MenuPermissions { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Pharmacy> Pharmacies { get; set; }

    public virtual DbSet<Prescription> Prescriptions { get; set; }

    public virtual DbSet<Reception> Receptions { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<ReportParameter> ReportParameters { get; set; }

    public virtual DbSet<ReportPermission> ReportPermissions { get; set; }

    public virtual DbSet<ServiceCatalog> ServiceCatalogs { get; set; }

    public virtual DbSet<ServiceGroup> ServiceGroups { get; set; }

    public virtual DbSet<ServiceStandardValue> ServiceStandardValues { get; set; }

    public virtual DbSet<Setting> Settings { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<Technician> Technicians { get; set; }

    public virtual DbSet<TemplatePrescription> TemplatePrescriptions { get; set; }

    public virtual DbSet<TemplatePrescriptionDrugMapping> TemplatePrescriptionDrugMappings { get; set; }

    public virtual DbSet<TypeOfControlInput> TypeOfControlInputs { get; set; }

    public virtual DbSet<UnitOfMeasure> UnitOfMeasures { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserAction> UserActions { get; set; }

    public virtual DbSet<UserActionByMedicalRecord> UserActionByMedicalRecords { get; set; }

    public virtual DbSet<UserDepartment> UserDepartments { get; set; }

    public virtual DbSet<UserPharmacy> UserPharmacies { get; set; }

    public virtual DbSet<ZaloUser> ZaloUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=laptop;Database=freshx_en;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdministrativeUnit>(entity =>
        {
            entity.HasKey(e => e.AdministrativeUnitId).HasName("PK__Administ__8F20DAEA0BE80568");

            entity.ToTable("AdministrativeUnit");

            entity.Property(e => e.Code).HasMaxLength(150);
            entity.Property(e => e.HismappingId).HasColumnName("HISMappingId");
            entity.Property(e => e.Level).HasMaxLength(150);
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.AppointmentId).HasName("PK__Appointm__8ECDFCC275E45C21");

            entity.ToTable("Appointment");

            entity.Property(e => e.AppointmentTime).HasColumnType("datetime");
            entity.Property(e => e.SentTime).HasColumnType("datetime");

            entity.HasOne(d => d.MedicalExamination).WithMany(p => p.Appointments)
                .HasPrincipalKey(p => p.MedicalExaminationId)
                .HasForeignKey(d => d.MedicalExaminationId)
                .HasConstraintName("FK_Appointment_MedicalExamination");

            entity.HasOne(d => d.Patient).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK_Appointment_Patient");

            entity.HasOne(d => d.Reception).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.ReceptionId)
                .HasConstraintName("FK_Appointment_Reception");
        });

        modelBuilder.Entity<ConclusionDictionary>(entity =>
        {
            entity.HasKey(e => e.ConclusionDictionaryId).HasName("PK__Conclusi__F2BBBBF9E437A07C");

            entity.ToTable("ConclusionDictionary");

            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.Conclusion).HasColumnType("ntext");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasColumnType("ntext");
            entity.Property(e => e.Diagnosis).HasMaxLength(500);
            entity.Property(e => e.MedicalAdvice).HasColumnType("ntext");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.Note).HasColumnType("ntext");
            entity.Property(e => e.SequenceNumber).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(500);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.ServiceCatalog).WithMany(p => p.ConclusionDictionaries)
                .HasForeignKey(d => d.ServiceCatalogId)
                .HasConstraintName("FK_ConclusionDictionary_ServiceCatalog");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("PK__Country__10D1609F86DBE856");

            entity.ToTable("Country");

            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.NameEnglish).HasMaxLength(250);
            entity.Property(e => e.NameLatin).HasMaxLength(250);
            entity.Property(e => e.ShortName).HasMaxLength(250);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BED67F03F92");

            entity.ToTable("Department");

            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.DepartmentType).WithMany(p => p.Departments)
                .HasForeignKey(d => d.DepartmentTypeId)
                .HasConstraintName("FK_Department_DepartmentType");
        });

        modelBuilder.Entity<DepartmentType>(entity =>
        {
            entity.HasKey(e => e.DepartmentTypeId).HasName("PK__Departme__FC33D097AB2A9DAC");

            entity.ToTable("DepartmentType");

            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<DiagnosisDictionary>(entity =>
        {
            entity.HasKey(e => e.DiagnosisDictionaryId).HasName("PK__Diagnosi__8AD752220B74DEE3");

            entity.ToTable("DiagnosisDictionary");

            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.MedicalAdvice).HasColumnType("ntext");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.SequenceNumber).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(500);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<DiagnosticImagingResult>(entity =>
        {
            entity.HasKey(e => e.DiagnosticImagingResultId).HasName("PK__Diagnost__5FF562EE9E038679");

            entity.ToTable("DiagnosticImagingResult");

            entity.Property(e => e.Conclusion).HasColumnType("ntext");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasColumnType("ntext");
            entity.Property(e => e.ExecutionDate).HasColumnType("datetime");
            entity.Property(e => e.ExecutionTime).HasColumnType("datetime");
            entity.Property(e => e.GpbmacroDescription)
                .HasColumnType("ntext")
                .HasColumnName("GPBMacroDescription");
            entity.Property(e => e.GpbmicroDescription)
                .HasColumnType("ntext")
                .HasColumnName("GPBMicroDescription");
            entity.Property(e => e.Instruction).HasColumnType("ntext");
            entity.Property(e => e.Note).HasColumnType("ntext");
            entity.Property(e => e.OtherComment).HasMaxLength(500);
            entity.Property(e => e.Result).HasMaxLength(500);
            entity.Property(e => e.SampleCollectionDate).HasColumnType("datetime");
            entity.Property(e => e.SampleCollectionLocation).HasMaxLength(50);
            entity.Property(e => e.SampleCollectionTime).HasColumnType("datetime");
            entity.Property(e => e.SampleReceivedDate).HasColumnType("datetime");
            entity.Property(e => e.SampleReceivedTime).HasColumnType("datetime");
            entity.Property(e => e.SpouseName).HasMaxLength(500);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.ConcludingDoctor).WithMany(p => p.DiagnosticImagingResults)
                .HasForeignKey(d => d.ConcludingDoctorId)
                .HasConstraintName("FK_DiagnosticImagingResult_ConcludingDoctor");

            entity.HasOne(d => d.MedicalServiceRequest).WithMany(p => p.DiagnosticImagingResults)
                .HasForeignKey(d => d.MedicalServiceRequestId)
                .HasConstraintName("FK_DiagnosticImagingResult_MedicalServiceRequest");

            entity.HasOne(d => d.Patient).WithMany(p => p.DiagnosticImagingResults)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK_DiagnosticImagingResult_Patient");

            entity.HasOne(d => d.Reception).WithMany(p => p.DiagnosticImagingResults)
                .HasForeignKey(d => d.ReceptionId)
                .HasConstraintName("FK_DiagnosticImagingResult_Reception");

            entity.HasOne(d => d.SampleCollector).WithMany(p => p.DiagnosticImagingResults)
                .HasForeignKey(d => d.SampleCollectorId)
                .HasConstraintName("FK_DiagnosticImagingResult_SampleCollector");

            entity.HasOne(d => d.Technician).WithMany(p => p.DiagnosticImagingResults)
                .HasForeignKey(d => d.TechnicianId)
                .HasConstraintName("FK_DiagnosticImagingResult_Technician");
        });

        modelBuilder.Entity<DiagnosticImagingResultImage>(entity =>
        {
            entity.HasKey(e => e.DiagnosticImagingResultImageId).HasName("PK__Diagnost__B1F8FB579AC90E95");

            entity.ToTable("DiagnosticImagingResultImage");

            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.Url)
                .HasMaxLength(500)
                .HasColumnName("URL");

            entity.HasOne(d => d.DiagnosticImagingResult).WithMany(p => p.DiagnosticImagingResultImages)
                .HasForeignKey(d => d.DiagnosticImagingResultId)
                .HasConstraintName("FK_DiagnosticImagingResultImage_DiagnosticImagingResult");
        });

        modelBuilder.Entity<Dictionary>(entity =>
        {
            entity.HasKey(e => e.DictionaryId).HasName("PK__Dictiona__15ACD2E77B6A9587");

            entity.ToTable("Dictionary");

            entity.Property(e => e.Code).HasMaxLength(250);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description1).HasMaxLength(500);
            entity.Property(e => e.Description2).HasMaxLength(500);
            entity.Property(e => e.Description3).HasMaxLength(500);
            entity.Property(e => e.Description4).HasMaxLength(500);
            entity.Property(e => e.Description5).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(500);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<DiseaseGroup>(entity =>
        {
            entity.HasKey(e => e.DiseaseGroupId).HasName("PK__DiseaseG__1AFF73794B9D3F46");

            entity.ToTable("DiseaseGroup");

            entity.Property(e => e.Code).HasMaxLength(150);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(500);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.DoctorId).HasName("PK__Doctor__2DC00EBF75E56BEB");

            entity.ToTable("Doctor");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<DoctorsCommonIcd>(entity =>
        {
            entity.HasKey(e => e.DoctorsCommonIcdid).HasName("PK__DoctorsC__72BF9135CB01BE52");

            entity.ToTable("DoctorsCommonICD");

            entity.Property(e => e.DoctorsCommonIcdid).HasColumnName("DoctorsCommonICDId");
            entity.Property(e => e.IcdcatalogId).HasColumnName("ICDCatalogId");

            entity.HasOne(d => d.Doctor).WithMany(p => p.DoctorsCommonIcds)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DoctorsCommonICD_Doctor");

            entity.HasOne(d => d.Icdcatalog).WithMany(p => p.DoctorsCommonIcds)
                .HasForeignKey(d => d.IcdcatalogId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DoctorsCommonICD_ICDCatalog");
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.DocumentId).HasName("PK__Document__1ABEEF0FB31932BC");

            entity.ToTable("Document");

            entity.Property(e => e.AccountingDocument)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.CreditAccount)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.CurrencyId)
                .HasMaxLength(3)
                .IsFixedLength();
            entity.Property(e => e.DebitAccount)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.DiscountAmount).HasColumnType("numeric(26, 2)");
            entity.Property(e => e.DiscountRate).HasColumnType("numeric(5, 2)");
            entity.Property(e => e.DocumentCode)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.DocumentDate).HasColumnType("smalldatetime");
            entity.Property(e => e.DocumentNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.DocumentType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ExchangeRate).HasColumnType("numeric(9, 2)");
            entity.Property(e => e.ForeignInvoiceDate).HasColumnType("smalldatetime");
            entity.Property(e => e.ForeignInvoiceNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ForeignSerialNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FormCode).HasMaxLength(20);
            entity.Property(e => e.GeneratedTransactionDescription).HasMaxLength(100);
            entity.Property(e => e.ImportVatamount)
                .HasColumnType("numeric(26, 2)")
                .HasColumnName("ImportVATAmount");
            entity.Property(e => e.ImportVatrate)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("ImportVATRate");
            entity.Property(e => e.InputDate).HasColumnType("datetime");
            entity.Property(e => e.InvoiceNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.MaterialTypeId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.OriginalDocumentDate).HasColumnType("smalldatetime");
            entity.Property(e => e.OriginalDocumentNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.PaymentValue).HasColumnType("numeric(26, 2)");
            entity.Property(e => e.ReferenceDocumentCode)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ReferenceDocumentType)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.SerialNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TaxAmount).HasColumnType("numeric(26, 2)");
            entity.Property(e => e.TaxRate).HasColumnType("numeric(5, 2)");
            entity.Property(e => e.TotalValue).HasColumnType("numeric(26, 2)");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.Vatamount)
                .HasColumnType("numeric(26, 2)")
                .HasColumnName("VATAmount");
            entity.Property(e => e.Vatrate)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("VATRate");

            entity.HasOne(d => d.Approver).WithMany(p => p.DocumentApprovers)
                .HasForeignKey(d => d.ApproverId)
                .HasConstraintName("FK_Document_Approver");

            entity.HasOne(d => d.ChiefAccountant).WithMany(p => p.DocumentChiefAccountants)
                .HasForeignKey(d => d.ChiefAccountantId)
                .HasConstraintName("FK_Document_ChiefAccountant");

            entity.HasOne(d => d.CorrespondingPharmacy).WithMany(p => p.DocumentCorrespondingPharmacies)
                .HasForeignKey(d => d.CorrespondingPharmacyId)
                .HasConstraintName("FK_Document_CorrespondingPharmacy");

            entity.HasOne(d => d.Deliverer).WithMany(p => p.DocumentDeliverers)
                .HasForeignKey(d => d.DelivererId)
                .HasConstraintName("FK_Document_Deliverer");

            entity.HasOne(d => d.Department).WithMany(p => p.Documents)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_Document_Department");

            entity.HasOne(d => d.Doctor).WithMany(p => p.DocumentDoctors)
                .HasForeignKey(d => d.DoctorId)
                .HasConstraintName("FK_Document_Doctor");

            entity.HasOne(d => d.DocumentPurpose).WithMany(p => p.Documents)
                .HasForeignKey(d => d.DocumentPurposeId)
                .HasConstraintName("FK_Document_DocumentPurpose");

            entity.HasOne(d => d.ExecutionPharmacy).WithMany(p => p.DocumentExecutionPharmacies)
                .HasForeignKey(d => d.ExecutionPharmacyId)
                .HasConstraintName("FK_Document_ExecutionPharmacy");

            entity.HasOne(d => d.Inputter).WithMany(p => p.DocumentInputters)
                .HasForeignKey(d => d.InputterId)
                .HasConstraintName("FK_Document_Inputter");

            entity.HasOne(d => d.Inspector).WithMany(p => p.DocumentInspectors)
                .HasForeignKey(d => d.InspectorId)
                .HasConstraintName("FK_Document_Inspector");

            entity.HasOne(d => d.IssuingPharmacy).WithMany(p => p.DocumentIssuingPharmacies)
                .HasForeignKey(d => d.IssuingPharmacyId)
                .HasConstraintName("FK_Document_IssuingPharmacy");

            entity.HasOne(d => d.MedicalExamination).WithMany(p => p.Documents)
                .HasPrincipalKey(p => p.MedicalExaminationId)
                .HasForeignKey(d => d.MedicalExaminationId)
                .HasConstraintName("FK_Document_MedicalExamination");

            entity.HasOne(d => d.Receiver).WithMany(p => p.DocumentReceivers)
                .HasForeignKey(d => d.ReceiverId)
                .HasConstraintName("FK_Document_Receiver");

            entity.HasOne(d => d.ReceivingPharmacy).WithMany(p => p.DocumentReceivingPharmacies)
                .HasForeignKey(d => d.ReceivingPharmacyId)
                .HasConstraintName("FK_Document_ReceivingPharmacy");

            entity.HasOne(d => d.ReferralDoctor).WithMany(p => p.DocumentReferralDoctors)
                .HasForeignKey(d => d.ReferralDoctorId)
                .HasConstraintName("FK_Document_ReferralDoctor");

            entity.HasOne(d => d.RelatedDocument).WithMany(p => p.InverseRelatedDocument)
                .HasForeignKey(d => d.RelatedDocumentId)
                .HasConstraintName("FK_Document_RelatedDocument");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Documents)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK_Document_Supplier");

            entity.HasOne(d => d.Treasurer).WithMany(p => p.DocumentTreasurers)
                .HasForeignKey(d => d.TreasurerId)
                .HasConstraintName("FK_Document_Treasurer");

            entity.HasOne(d => d.UsagePharmacy).WithMany(p => p.DocumentUsagePharmacies)
                .HasForeignKey(d => d.UsagePharmacyId)
                .HasConstraintName("FK_Document_UsagePharmacy");
        });

        modelBuilder.Entity<DocumentDetail>(entity =>
        {
            entity.HasKey(e => e.DocumentDetailId).HasName("PK__Document__9885B82C5A34C6BD");

            entity.ToTable("DocumentDetail");

            entity.Property(e => e.AccountingDocumentNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ActualQuantity).HasColumnType("numeric(9, 2)");
            entity.Property(e => e.BookNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CashDocumentNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ControlNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CostPrice).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.CostPriceIncludingVat)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("CostPriceIncludingVAT");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.CurrencyId)
                .HasMaxLength(3)
                .IsFixedLength();
            entity.Property(e => e.ExchangeRate).HasColumnType("numeric(9, 2)");
            entity.Property(e => e.IssuedQuantity).HasColumnType("numeric(9, 2)");
            entity.Property(e => e.Note).HasMaxLength(255);
            entity.Property(e => e.OriginalQuantity).HasColumnType("numeric(9, 2)");
            entity.Property(e => e.PaymentPrice).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.PurchasePrice).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.RequestedQuantity).HasColumnType("numeric(9, 2)");
            entity.Property(e => e.SellingPrice).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TotalCostAmount).HasColumnType("numeric(27, 4)");
            entity.Property(e => e.TotalPurchaseAmount).HasColumnType("numeric(27, 4)");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.Vatamount)
                .HasColumnType("numeric(26, 2)")
                .HasColumnName("VATAmount");
            entity.Property(e => e.VatinvoiceNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("VATInvoiceNumber");
            entity.Property(e => e.Vatrate)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("VATRate");
            entity.Property(e => e.VisaNumber)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Document).WithMany(p => p.DocumentDetails)
                .HasForeignKey(d => d.DocumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DocumentDetail_Document");

            entity.HasOne(d => d.DrugCatalog).WithMany(p => p.DocumentDetails)
                .HasForeignKey(d => d.DrugCatalogId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DocumentDetail_DrugCatalog");

            entity.HasOne(d => d.OriginalUnitOfMeasure).WithMany(p => p.DocumentDetailOriginalUnitOfMeasures)
                .HasForeignKey(d => d.OriginalUnitOfMeasureId)
                .HasConstraintName("FK_DocumentDetail_OriginalUnitOfMeasure");

            entity.HasOne(d => d.UnitOfMeasure).WithMany(p => p.DocumentDetailUnitOfMeasures)
                .HasForeignKey(d => d.UnitOfMeasureId)
                .HasConstraintName("FK_DocumentDetail_UnitOfMeasure");
        });

        modelBuilder.Entity<DocumentPurpose>(entity =>
        {
            entity.HasKey(e => e.DocumentPurposeId).HasName("PK__Document__80AD6E769159AFA7");

            entity.ToTable("DocumentPurpose");

            entity.Property(e => e.Code).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<DrugBooking>(entity =>
        {
            entity.HasKey(e => e.DrugBookingId).HasName("PK__DrugBook__2DD3919EB927E719");

            entity.ToTable("DrugBooking");

            entity.Property(e => e.Action).HasMaxLength(50);
            entity.Property(e => e.AfternoonDose).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.DaysOfSupply).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.EveningDose).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.MorningDose).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.NoonDose).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.Note).HasMaxLength(500);
            entity.Property(e => e.Quantity).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.TotalAmount).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.UnitPrice).HasColumnType("numeric(18, 2)");

            entity.HasOne(d => d.DrugCatalog).WithMany(p => p.DrugBookings)
                .HasForeignKey(d => d.DrugCatalogId)
                .HasConstraintName("FK_DrugBooking_DrugCatalog");

            entity.HasOne(d => d.LoginSession).WithMany(p => p.DrugBookings)
                .HasForeignKey(d => d.LoginSessionId)
                .HasConstraintName("FK_DrugBooking_LoginSession");

            entity.HasOne(d => d.MedicalExamination).WithMany(p => p.DrugBookings)
                .HasPrincipalKey(p => p.MedicalExaminationId)
                .HasForeignKey(d => d.MedicalExaminationId)
                .HasConstraintName("FK_DrugBooking_MedicalExamination");

            entity.HasOne(d => d.Prescription).WithMany(p => p.DrugBookings)
                .HasForeignKey(d => d.PrescriptionId)
                .HasConstraintName("FK_DrugBooking_Prescription");
        });

        modelBuilder.Entity<DrugCatalog>(entity =>
        {
            entity.HasKey(e => e.DrugCatalogId).HasName("PK__DrugCata__F4EB60A052FC5EA4");

            entity.ToTable("DrugCatalog");

            entity.Property(e => e.Code).HasMaxLength(150);
            entity.Property(e => e.CostPrice).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Dosage).HasMaxLength(250);
            entity.Property(e => e.DrugClassification).HasMaxLength(50);
            entity.Property(e => e.Effect).HasMaxLength(250);
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.NationalDrugCode).HasMaxLength(250);
            entity.Property(e => e.QuantityImported).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.QuantityInStock).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.ReferenceNumber).HasMaxLength(500);
            entity.Property(e => e.RouteOfAdministration).HasMaxLength(250);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.UnitPrice).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Country).WithMany(p => p.DrugCatalogs)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_DrugCatalog_Country");

            entity.HasOne(d => d.DepartmentPharmacy).WithMany(p => p.DrugCatalogDepartmentPharmacies)
                .HasForeignKey(d => d.DepartmentPharmacyId)
                .HasConstraintName("FK_DrugCatalog_DepartmentPharmacy");

            entity.HasOne(d => d.DrugType).WithMany(p => p.DrugCatalogs)
                .HasForeignKey(d => d.DrugTypeId)
                .HasConstraintName("FK_DrugCatalog_DrugType");

            entity.HasOne(d => d.ManagementPharmacy).WithMany(p => p.DrugCatalogManagementPharmacies)
                .HasForeignKey(d => d.ManagementPharmacyId)
                .HasConstraintName("FK_DrugCatalog_ManagementPharmacy");

            entity.HasOne(d => d.Manufacturer).WithMany(p => p.DrugCatalogs)
                .HasForeignKey(d => d.ManufacturerId)
                .HasConstraintName("FK_DrugCatalog_Manufacturer");

            entity.HasOne(d => d.UnitOfMeasure).WithMany(p => p.DrugCatalogs)
                .HasForeignKey(d => d.UnitOfMeasureId)
                .HasConstraintName("FK_DrugCatalog_UnitOfMeasure");
        });

        modelBuilder.Entity<DrugType>(entity =>
        {
            entity.HasKey(e => e.DrugTypeId).HasName("PK__DrugType__718B4FB9D86D053B");

            entity.ToTable("DrugType");

            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(500);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<EinvoiceFile>(entity =>
        {
            entity.HasKey(e => e.EinvoiceFileId).HasName("PK__EInvoice__3C0B525F997F9CA1");

            entity.ToTable("EInvoiceFile");

            entity.Property(e => e.EinvoiceFileId).HasColumnName("EInvoiceFileId");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Invoice).WithMany(p => p.EinvoiceFiles)
                .HasForeignKey(d => d.InvoiceId)
                .HasConstraintName("FK_EInvoiceFile_Invoice");

            entity.HasOne(d => d.Patient).WithMany(p => p.EinvoiceFiles)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK_EInvoiceFile_Patient");
        });

        modelBuilder.Entity<EmailAccount>(entity =>
        {
            entity.HasKey(e => e.EmailAccountId).HasName("PK__EmailAcc__D74D479806E0E9EE");

            entity.ToTable("EmailAccount");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.EmailAddress).HasMaxLength(250);
            entity.Property(e => e.Password).HasMaxLength(500);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<EmailContent>(entity =>
        {
            entity.HasKey(e => e.EmailContentId).HasName("PK__EmailCon__095C5B43A29C8DC1");

            entity.ToTable("EmailContent");

            entity.Property(e => e.Content).HasColumnType("ntext");
            entity.Property(e => e.SentDate).HasColumnType("datetime");
            entity.Property(e => e.Subject).HasMaxLength(250);

            entity.HasOne(d => d.Sender).WithMany(p => p.EmailContents)
                .HasForeignKey(d => d.SenderId)
                .HasConstraintName("FK_EmailContent_Sender");
        });

        modelBuilder.Entity<EmailContentImage>(entity =>
        {
            entity.HasKey(e => e.EmailContentImageId).HasName("PK__EmailCon__FE7ECD7FD32BA333");

            entity.ToTable("EmailContentImage");

            entity.Property(e => e.ImageName).HasMaxLength(250);
            entity.Property(e => e.ImageUrl)
                .HasColumnType("ntext")
                .HasColumnName("ImageURL");

            entity.HasOne(d => d.EmailContent).WithMany(p => p.EmailContentImages)
                .HasForeignKey(d => d.EmailContentId)
                .HasConstraintName("FK_EmailContentImage_EmailContent");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04F11647AC759");

            entity.ToTable("Employee");

            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.EmployeeCode).HasMaxLength(30);
            entity.Property(e => e.FirstName).HasMaxLength(20);
            entity.Property(e => e.Gender).HasMaxLength(20);
            entity.Property(e => e.IssuancePlace).HasMaxLength(200);
            entity.Property(e => e.LastName).HasMaxLength(20);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.ProfessionalCertificate).HasMaxLength(100);

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_Employee_Department");

            entity.HasOne(d => d.District).WithMany(p => p.EmployeeDistricts)
                .HasForeignKey(d => d.DistrictId)
                .HasConstraintName("FK_Employee_District");

            entity.HasOne(d => d.Province).WithMany(p => p.EmployeeProvinces)
                .HasForeignKey(d => d.ProvinceId)
                .HasConstraintName("FK_Employee_Province");

            entity.HasOne(d => d.Ward).WithMany(p => p.EmployeeWards)
                .HasForeignKey(d => d.WardId)
                .HasConstraintName("FK_Employee_Ward");
        });

        modelBuilder.Entity<ExaminationConfirmation>(entity =>
        {
            entity.HasKey(e => e.ExaminationConfirmationId).HasName("PK__Examinat__297DA0BD928BC45E");

            entity.ToTable("ExaminationConfirmation");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.MedicalExamination).WithMany(p => p.ExaminationConfirmations)
                .HasPrincipalKey(p => p.MedicalExaminationId)
                .HasForeignKey(d => d.MedicalExaminationId)
                .HasConstraintName("FK_ExaminationConfirmation_MedicalExamination");

            entity.HasOne(d => d.Reception).WithMany(p => p.ExaminationConfirmations)
                .HasForeignKey(d => d.ReceptionId)
                .HasConstraintName("FK_ExaminationConfirmation_Reception");
        });

        modelBuilder.Entity<Hospital>(entity =>
        {
            entity.HasKey(e => e.HospitalId).HasName("PK__Hospital__38C2E5AF451F325C");

            entity.ToTable("Hospital");

            entity.Property(e => e.Address1).HasMaxLength(500);
            entity.Property(e => e.Address2).HasMaxLength(500);
            entity.Property(e => e.Address3).HasMaxLength(500);
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(500);
            entity.Property(e => e.PhoneNumber1).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber2).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber3).HasMaxLength(50);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Icdcatalog>(entity =>
        {
            entity.HasKey(e => e.IcdcatalogId).HasName("PK__ICDCatal__3FF6CA170278841B");

            entity.ToTable("ICDCatalog");

            entity.Property(e => e.IcdcatalogId).HasColumnName("ICDCatalogId");
            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.IcdcatalogGroupId).HasColumnName("ICDCatalogGroupId");
            entity.Property(e => e.Level)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.NameEnglish).HasMaxLength(200);
            entity.Property(e => e.NameRussian).HasMaxLength(200);
            entity.Property(e => e.NameUnaccented).HasMaxLength(200);
            entity.Property(e => e.Subgroup)
                .HasMaxLength(7)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.IcdcatalogGroup).WithMany(p => p.InverseIcdcatalogGroup)
                .HasForeignKey(d => d.IcdcatalogGroupId)
                .HasConstraintName("FK_ICDCatalog_ICDCatalogGroup");
        });

        modelBuilder.Entity<Icdchapter>(entity =>
        {
            entity.HasKey(e => e.IcdchapterId).HasName("PK__ICDChapt__B5EC92646268A705");

            entity.ToTable("ICDChapter");

            entity.Property(e => e.IcdchapterId).HasColumnName("ICDChapterId");
            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.NameEnglish).HasMaxLength(200);
            entity.Property(e => e.NameRussian).HasMaxLength(200);
            entity.Property(e => e.NameUnaccented).HasMaxLength(200);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<InventoryType>(entity =>
        {
            entity.HasKey(e => e.InventoryTypeId).HasName("PK__Inventor__464D386CF25C8F29");

            entity.ToTable("InventoryType");

            entity.Property(e => e.Code).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.InvoiceId).HasName("PK__Invoice__D796AAB563B7AE20");

            entity.ToTable("Invoice");

            entity.HasIndex(e => e.MedicalExaminationId, "UQ__Invoice__60CB94ED3814514F").IsUnique();

            entity.Property(e => e.Bmi)
                .HasMaxLength(50)
                .HasColumnName("BMI");
            entity.Property(e => e.Conclusion).HasColumnType("ntext");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedTime).HasColumnType("datetime");
            entity.Property(e => e.ExaminationDetails).HasColumnType("ntext");
            entity.Property(e => e.ExaminationNote).HasColumnType("ntext");
            entity.Property(e => e.FollowUpAppointment).HasColumnType("datetime");
            entity.Property(e => e.IcdcatalogId).HasColumnName("ICDCatalogId");
            entity.Property(e => e.InvoiceNumber).HasMaxLength(250);
            entity.Property(e => e.InvoiceType).HasMaxLength(50);
            entity.Property(e => e.LabSummary).HasColumnType("ntext");
            entity.Property(e => e.MedicalAdvice).HasColumnType("ntext");
            entity.Property(e => e.MedicalHistory).HasColumnType("ntext");
            entity.Property(e => e.PrescriptionNumber).HasMaxLength(50);
            entity.Property(e => e.ReasonForVisit).HasColumnType("ntext");
            entity.Property(e => e.RespiratoryRate).HasMaxLength(50);
            entity.Property(e => e.TreatmentDetails).HasColumnType("ntext");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.VatinvoiceNumber)
                .HasMaxLength(250)
                .HasColumnName("VATInvoiceNumber");

            entity.HasOne(d => d.Icdcatalog).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.IcdcatalogId)
                .HasConstraintName("FK_Invoice_ICDCatalog");

            entity.HasOne(d => d.Patient).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK_Invoice_Patient");

            entity.HasOne(d => d.Reception).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.ReceptionId)
                .HasConstraintName("FK_Invoice_Reception");
        });

        modelBuilder.Entity<LabResult>(entity =>
        {
            entity.HasKey(e => e.LabResultId).HasName("PK__LabResul__3CEBE3B6CA6C6916");

            entity.ToTable("LabResult");

            entity.Property(e => e.Conclusion).HasColumnType("ntext");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasColumnType("ntext");
            entity.Property(e => e.ExecutionDate).HasColumnType("datetime");
            entity.Property(e => e.ExecutionTime).HasColumnType("datetime");
            entity.Property(e => e.Instruction).HasColumnType("ntext");
            entity.Property(e => e.Note).HasColumnType("ntext");
            entity.Property(e => e.Result).HasMaxLength(500);
            entity.Property(e => e.SampleCollectionDate).HasColumnType("datetime");
            entity.Property(e => e.SampleCollectionTime).HasColumnType("datetime");
            entity.Property(e => e.SampleReceivedDate).HasColumnType("datetime");
            entity.Property(e => e.SampleReceivedTime).HasColumnType("datetime");
            entity.Property(e => e.SpouseName).HasMaxLength(500);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.ConcludingDoctor).WithMany(p => p.LabResults)
                .HasForeignKey(d => d.ConcludingDoctorId)
                .HasConstraintName("FK_LabResult_ConcludingDoctor");

            entity.HasOne(d => d.Patient).WithMany(p => p.LabResults)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK_LabResult_Patient");

            entity.HasOne(d => d.Reception).WithMany(p => p.LabResults)
                .HasForeignKey(d => d.ReceptionId)
                .HasConstraintName("FK_LabResult_Reception");

            entity.HasOne(d => d.Technician).WithMany(p => p.LabResults)
                .HasForeignKey(d => d.TechnicianId)
                .HasConstraintName("FK_LabResult_Technician");
        });

        modelBuilder.Entity<LabTestFile>(entity =>
        {
            entity.HasKey(e => e.LabTestFileId).HasName("PK__LabTestF__CF5F49649ECAA65C");

            entity.ToTable("LabTestFile");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Patient).WithMany(p => p.LabTestFiles)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK_LabTestFile_Patient");

            entity.HasOne(d => d.Reception).WithMany(p => p.LabTestFiles)
                .HasForeignKey(d => d.ReceptionId)
                .HasConstraintName("FK_LabTestFile_Reception");
        });

        modelBuilder.Entity<LoginSession>(entity =>
        {
            entity.HasKey(e => e.LoginSessionId).HasName("PK__LoginSes__5C18B36B96DC4127");

            entity.ToTable("LoginSession");

            entity.Property(e => e.Ipaddress)
                .HasMaxLength(50)
                .HasColumnName("IPAddress");
            entity.Property(e => e.LoginTime).HasColumnType("datetime");
            entity.Property(e => e.LogoutTime).HasColumnType("datetime");
            entity.Property(e => e.Macaddress)
                .HasMaxLength(150)
                .HasColumnName("MACAddress");

            entity.HasOne(d => d.Department).WithMany(p => p.LoginSessions)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_LoginSession_Department");

            entity.HasOne(d => d.Pharmacy).WithMany(p => p.LoginSessions)
                .HasForeignKey(d => d.PharmacyId)
                .HasConstraintName("FK_LoginSession_Pharmacy");

            entity.HasOne(d => d.User).WithMany(p => p.LoginSessions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_LoginSession_User");
        });

        modelBuilder.Entity<MedicalServiceRequest>(entity =>
        {
            entity.HasKey(e => e.MedicalServiceRequestId).HasName("PK__MedicalS__4E145F42C004B2C6");

            entity.ToTable("MedicalServiceRequest");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ExecutionDate).HasColumnType("datetime");
            entity.Property(e => e.ExecutionTime).HasColumnType("datetime");
            entity.Property(e => e.NumberOfTubes).HasMaxLength(50);
            entity.Property(e => e.RequestDate).HasColumnType("datetime");
            entity.Property(e => e.RequestNumber).HasMaxLength(150);
            entity.Property(e => e.RequestTime).HasColumnType("datetime");
            entity.Property(e => e.Result).HasMaxLength(500);
            entity.Property(e => e.SampleCollectionDate).HasColumnType("datetime");
            entity.Property(e => e.SampleCollectionTime).HasColumnType("datetime");
            entity.Property(e => e.ServiceTotalAmount).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.ServiceUnitPrice).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.Sid)
                .HasMaxLength(50)
                .HasColumnName("SID");
            entity.Property(e => e.Status).HasMaxLength(150);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.AssignedBy).WithMany(p => p.MedicalServiceRequestAssignedBies)
                .HasForeignKey(d => d.AssignedById)
                .HasConstraintName("FK_MedicalServiceRequest_AssignedBy");

            entity.HasOne(d => d.ParentMedicalServiceRequest).WithMany(p => p.InverseParentMedicalServiceRequest)
                .HasForeignKey(d => d.ParentMedicalServiceRequestId)
                .HasConstraintName("FK_MedicalServiceRequest_ParentMedicalServiceRequest");

            entity.HasOne(d => d.Patient).WithMany(p => p.MedicalServiceRequests)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK_MedicalServiceRequest_Patient");

            entity.HasOne(d => d.Reception).WithMany(p => p.MedicalServiceRequests)
                .HasForeignKey(d => d.ReceptionId)
                .HasConstraintName("FK_MedicalServiceRequest_Reception");

            entity.HasOne(d => d.SampleCollector).WithMany(p => p.MedicalServiceRequestSampleCollectors)
                .HasForeignKey(d => d.SampleCollectorId)
                .HasConstraintName("FK_MedicalServiceRequest_SampleCollector");

            entity.HasOne(d => d.Service).WithMany(p => p.MedicalServiceRequests)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK_MedicalServiceRequest_ServiceCatalog");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.MenuId).HasName("PK__Menu__C99ED230EF002143");

            entity.ToTable("Menu");

            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.ParentMenu).WithMany(p => p.InverseParentMenu)
                .HasForeignKey(d => d.ParentMenuId)
                .HasConstraintName("FK_Menu_ParentMenu");
        });

        modelBuilder.Entity<MenuPermission>(entity =>
        {
            entity.HasKey(e => e.MenuPermissionId).HasName("PK__MenuPerm__830F63C5427A8501");

            entity.ToTable("MenuPermission");

            entity.HasOne(d => d.Menu).WithMany(p => p.MenuPermissions)
                .HasForeignKey(d => d.MenuId)
                .HasConstraintName("FK_MenuPermission_Menu");

            entity.HasOne(d => d.User).WithMany(p => p.MenuPermissions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_MenuPermission_User");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.PatientId).HasName("PK__Patient__970EC366523112BB");

            entity.ToTable("Patient");

            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.AdmissionNumber).HasMaxLength(50);
            entity.Property(e => e.CompanyName).HasMaxLength(500);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.IdentityCardNumber).HasMaxLength(50);
            entity.Property(e => e.ImageUrl).HasColumnName("ImageURL");
            entity.Property(e => e.MedicalRecordNumber).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(500);
            entity.Property(e => e.PhoneNumber).HasMaxLength(50);
            entity.Property(e => e.TaxCode).HasMaxLength(250);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.ZaloId).HasMaxLength(250);

            entity.HasOne(d => d.District).WithMany(p => p.PatientDistricts)
                .HasForeignKey(d => d.DistrictId)
                .HasConstraintName("FK_Patient_District");

            entity.HasOne(d => d.Province).WithMany(p => p.PatientProvinces)
                .HasForeignKey(d => d.ProvinceId)
                .HasConstraintName("FK_Patient_Province");

            entity.HasOne(d => d.Ward).WithMany(p => p.PatientWards)
                .HasForeignKey(d => d.WardId)
                .HasConstraintName("FK_Patient_Ward");
        });

        modelBuilder.Entity<Pharmacy>(entity =>
        {
            entity.HasKey(e => e.PharmacyId).HasName("PK__Pharmacy__BD9D2AAEE2712AFA");

            entity.ToTable("Pharmacy");

            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.NameUnaccented).HasMaxLength(100);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Department).WithMany(p => p.Pharmacies)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_Pharmacy_Department");

            entity.HasOne(d => d.InventoryType).WithMany(p => p.Pharmacies)
                .HasForeignKey(d => d.InventoryTypeId)
                .HasConstraintName("FK_Pharmacy_InventoryType");
        });

        modelBuilder.Entity<Prescription>(entity =>
        {
            entity.HasKey(e => e.PrescriptionId).HasName("PK__Prescrip__40130832D851B27E");

            entity.ToTable("Prescription");

            entity.Property(e => e.AfternoonDose).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DaysOfSupply).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.DispensedQuantity).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.EveningDose).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.MorningDose).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.NoonDose).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.PrescriptionNumber).HasMaxLength(50);
            entity.Property(e => e.Quantity).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.TotalAmount).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.UnitPrice).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.DrugCatalog).WithMany(p => p.Prescriptions)
                .HasForeignKey(d => d.DrugCatalogId)
                .HasConstraintName("FK_Prescription_DrugCatalog");

            entity.HasOne(d => d.MedicalExamination).WithMany(p => p.Prescriptions)
                .HasPrincipalKey(p => p.MedicalExaminationId)
                .HasForeignKey(d => d.MedicalExaminationId)
                .HasConstraintName("FK_Prescription_MedicalExamination");
        });

        modelBuilder.Entity<Reception>(entity =>
        {
            entity.HasKey(e => e.ReceptionId).HasName("PK__Receptio__8CE511FDD5A32130");

            entity.ToTable("Reception");

            entity.Property(e => e.ContactAddress).HasMaxLength(500);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Note).HasMaxLength(500);
            entity.Property(e => e.ReasonForVisit).HasMaxLength(500);
            entity.Property(e => e.ReceptionDate).HasColumnType("datetime");
            entity.Property(e => e.ReceptionNumber).HasMaxLength(50);
            entity.Property(e => e.ReceptionTime).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.AssignedDoctor).WithMany(p => p.Receptions)
                .HasForeignKey(d => d.AssignedDoctorId)
                .HasConstraintName("FK_Reception_AssignedDoctor");

            entity.HasOne(d => d.Patient).WithMany(p => p.Receptions)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK_Reception_Patient");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.ReportId).HasName("PK__Report__D5BD48057AA5C587");

            entity.ToTable("Report");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ProcedureName).HasMaxLength(500);
            entity.Property(e => e.ReportCode).HasMaxLength(100);
            entity.Property(e => e.ReportFile).HasMaxLength(500);
            entity.Property(e => e.ReportName).HasMaxLength(100);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<ReportParameter>(entity =>
        {
            entity.HasKey(e => e.ReportParameterId).HasName("PK__ReportPa__8C6CB092E3D85180");

            entity.ToTable("ReportParameter");

            entity.Property(e => e.DisplayName).HasMaxLength(100);
            entity.Property(e => e.ParameterName).HasMaxLength(100);
            entity.Property(e => e.ValueStringCheckBoxFalse).HasMaxLength(100);
            entity.Property(e => e.ValueStringCheckBoxTrue).HasMaxLength(100);

            entity.HasOne(d => d.Report).WithMany(p => p.ReportParameters)
                .HasForeignKey(d => d.ReportId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReportParameter_Report");

            entity.HasOne(d => d.TypeOfControlInput).WithMany(p => p.ReportParameters)
                .HasForeignKey(d => d.TypeOfControlInputId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReportParameter_TypeOfControlInput");
        });

        modelBuilder.Entity<ReportPermission>(entity =>
        {
            entity.HasKey(e => e.ReportPermissionId).HasName("PK__ReportPe__0C4B4FF17B551C53");

            entity.ToTable("ReportPermission");

            entity.HasOne(d => d.Report).WithMany(p => p.ReportPermissions)
                .HasForeignKey(d => d.ReportId)
                .HasConstraintName("FK_ReportPermission_Report");

            entity.HasOne(d => d.User).WithMany(p => p.ReportPermissions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_ReportPermission_User");
        });

        modelBuilder.Entity<ServiceCatalog>(entity =>
        {
            entity.HasKey(e => e.ServiceCatalogId).HasName("PK__ServiceC__B9F264EEB3E3FBA1");

            entity.ToTable("ServiceCatalog");

            entity.Property(e => e.Code).HasMaxLength(150);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(500);
            entity.Property(e => e.Price).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.UnitOfMeasure).HasMaxLength(150);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.ParentService).WithMany(p => p.InverseParentService)
                .HasForeignKey(d => d.ParentServiceId)
                .HasConstraintName("FK_ServiceCatalog_ParentService");

            entity.HasOne(d => d.ServiceGroup).WithMany(p => p.ServiceCatalogs)
                .HasForeignKey(d => d.ServiceGroupId)
                .HasConstraintName("FK_ServiceCatalog_ServiceGroup");
        });

        modelBuilder.Entity<ServiceGroup>(entity =>
        {
            entity.HasKey(e => e.ServiceGroupId).HasName("PK__ServiceG__2F2BE151FE033531");

            entity.ToTable("ServiceGroup");

            entity.Property(e => e.Code).HasMaxLength(150);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(500);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<ServiceStandardValue>(entity =>
        {
            entity.HasKey(e => e.ServiceStandardValueId).HasName("PK__ServiceS__DE5205E410CABED5");

            entity.ToTable("ServiceStandardValue");

            entity.Property(e => e.ChildrenMaximum).HasMaxLength(150);
            entity.Property(e => e.ChildrenMinimum).HasMaxLength(150);
            entity.Property(e => e.CommonValue).HasMaxLength(500);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.FemaleMaximum).HasMaxLength(150);
            entity.Property(e => e.FemaleMinimum).HasMaxLength(150);
            entity.Property(e => e.MaleMaximum).HasMaxLength(150);
            entity.Property(e => e.MaleMinimum).HasMaxLength(150);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.ServiceCatalog).WithMany(p => p.ServiceStandardValues)
                .HasForeignKey(d => d.ServiceCatalogId)
                .HasConstraintName("FK_ServiceStandardValue_ServiceCatalog");
        });

        modelBuilder.Entity<Setting>(entity =>
        {
            entity.HasKey(e => e.SettingId).HasName("PK__Setting__54372B1D4E77756E");

            entity.ToTable("Setting");

            entity.Property(e => e.Code).HasMaxLength(250);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Date1).HasColumnType("datetime");
            entity.Property(e => e.Date2).HasColumnType("datetime");
            entity.Property(e => e.Description).HasColumnType("ntext");
            entity.Property(e => e.Name).HasMaxLength(500);
            entity.Property(e => e.String1).HasMaxLength(250);
            entity.Property(e => e.String2).HasMaxLength(250);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("PK__Supplier__4BE666B4469AFAC5");

            entity.ToTable("Supplier");

            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ContactPerson).HasMaxLength(30);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Director).HasMaxLength(30);
            entity.Property(e => e.Email).HasMaxLength(30);
            entity.Property(e => e.Fax).HasMaxLength(30);
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.NameEnglish).HasMaxLength(200);
            entity.Property(e => e.NameRussian).HasMaxLength(200);
            entity.Property(e => e.NameUnaccented).HasMaxLength(200);
            entity.Property(e => e.PhoneNumber).HasMaxLength(30);
            entity.Property(e => e.TaxCode).HasMaxLength(20);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Technician>(entity =>
        {
            entity.HasKey(e => e.TechnicianId).HasName("PK__Technici__301F81211A2809A0");

            entity.ToTable("Technician");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TemplatePrescription>(entity =>
        {
            entity.HasKey(e => e.TemplatePrescriptionId).HasName("PK__Template__2D8377C6240C6997");

            entity.ToTable("TemplatePrescription");

            entity.Property(e => e.Code).HasMaxLength(150);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(500);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TemplatePrescriptionDrugMapping>(entity =>
        {
            entity.HasKey(e => e.TemplatePrescriptionDrugMappingId).HasName("PK__Template__F61E1CF9E45AC1FE");

            entity.ToTable("TemplatePrescriptionDrugMapping");

            entity.Property(e => e.AfternoonDose).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DaysOfSupply).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.EveningDose).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.MorningDose).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.NoonDose).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.Quantity).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.DrugCatalog).WithMany(p => p.TemplatePrescriptionDrugMappings)
                .HasForeignKey(d => d.DrugCatalogId)
                .HasConstraintName("FK_TemplatePrescriptionDrugMapping_DrugCatalog");

            entity.HasOne(d => d.TemplatePrescription).WithMany(p => p.TemplatePrescriptionDrugMappings)
                .HasForeignKey(d => d.TemplatePrescriptionId)
                .HasConstraintName("FK_TemplatePrescriptionDrugMapping_TemplatePrescription");
        });

        modelBuilder.Entity<TypeOfControlInput>(entity =>
        {
            entity.HasKey(e => e.TypeOfControlInputId).HasName("PK__TypeOfCo__13EA04E86CFE8737");

            entity.ToTable("TypeOfControlInput");

            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(250);
        });

        modelBuilder.Entity<UnitOfMeasure>(entity =>
        {
            entity.HasKey(e => e.UnitOfMeasureId).HasName("PK__UnitOfMe__F36083F1FF58790C");

            entity.ToTable("UnitOfMeasure");

            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.ConversionValue).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DrugType).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CC4C12228B7B");

            entity.ToTable("User");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Password).HasMaxLength(500);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.UserCode).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(250);

            entity.HasOne(d => d.Hospital).WithMany(p => p.Users)
                .HasForeignKey(d => d.HospitalId)
                .HasConstraintName("FK_User_Hospital");
        });

        modelBuilder.Entity<UserAction>(entity =>
        {
            entity.HasKey(e => e.UserActionId).HasName("PK__UserActi__40CADC22E99C325B");

            entity.ToTable("UserAction");

            entity.Property(e => e.Action).HasMaxLength(50);

            entity.HasOne(d => d.LoginSession).WithMany(p => p.UserActions)
                .HasForeignKey(d => d.LoginSessionId)
                .HasConstraintName("FK_UserAction_LoginSession");

            entity.HasOne(d => d.Service).WithMany(p => p.UserActions)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK_UserAction_ServiceCatalog");
        });

        modelBuilder.Entity<UserActionByMedicalRecord>(entity =>
        {
            entity.HasKey(e => e.UserActionByMedicalRecordId).HasName("PK__UserActi__DBC396A66EF4E56B");

            entity.ToTable("UserActionByMedicalRecord");

            entity.Property(e => e.Action).HasMaxLength(50);
            entity.Property(e => e.ActionTime).HasColumnType("datetime");
            entity.Property(e => e.AdmissionNumber).HasMaxLength(50);
            entity.Property(e => e.MedicalRecordNumber).HasMaxLength(50);

            entity.HasOne(d => d.LoginSession).WithMany(p => p.UserActionByMedicalRecords)
                .HasForeignKey(d => d.LoginSessionId)
                .HasConstraintName("FK_UserActionByMedicalRecord_LoginSession");

            entity.HasOne(d => d.User).WithMany(p => p.UserActionByMedicalRecords)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_UserActionByMedicalRecord_User");
        });

        modelBuilder.Entity<UserDepartment>(entity =>
        {
            entity.HasKey(e => e.UserDepartmentId).HasName("PK__UserDepa__2395A747E39E9D6E");

            entity.ToTable("UserDepartment");

            entity.HasOne(d => d.Department).WithMany(p => p.UserDepartments)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_UserDepartment_Department");

            entity.HasOne(d => d.User).WithMany(p => p.UserDepartments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_UserDepartment_User");
        });

        modelBuilder.Entity<UserPharmacy>(entity =>
        {
            entity.HasKey(e => e.UserPharmacyId).HasName("PK__UserPhar__FF3B478A923B7725");

            entity.ToTable("UserPharmacy");

            entity.HasOne(d => d.Pharmacy).WithMany(p => p.UserPharmacies)
                .HasForeignKey(d => d.PharmacyId)
                .HasConstraintName("FK_UserPharmacy_Pharmacy");

            entity.HasOne(d => d.User).WithMany(p => p.UserPharmacies)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_UserPharmacy_User");
        });

        modelBuilder.Entity<ZaloUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__ZaloUser__1788CC4C61025871");

            entity.ToTable("ZaloUser");

            entity.Property(e => e.UserId).HasMaxLength(50);
            entity.Property(e => e.Address).HasMaxLength(250);
            entity.Property(e => e.Avatar).HasMaxLength(250);
            entity.Property(e => e.City).HasMaxLength(250);
            entity.Property(e => e.DisplayName).HasMaxLength(250);
            entity.Property(e => e.District).HasMaxLength(250);
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.Phone).HasMaxLength(250);
            entity.Property(e => e.UserIdByApp).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

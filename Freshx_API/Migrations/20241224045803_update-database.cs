using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Freshx_API.Migrations
{
    /// <inheritdoc />
    public partial class updatedatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Invoices_MedicalExaminationId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Positions_PositionId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_DrugBookings_Invoices_MedicalExaminationId",
                table: "DrugBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_DrugBookings_LoginSessions_LoginSessionId",
                table: "DrugBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_DrugCatalogs_Pharmacies_ManagementPharmacyId",
                table: "DrugCatalogs");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalServiceRequests_Employees_AssignedById",
                table: "MedicalServiceRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalServiceRequests_Employees_SampleCollectorId",
                table: "MedicalServiceRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalServiceRequests_MedicalServiceRequests_ParentMedicalServiceRequestId",
                table: "MedicalServiceRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuPermissions_Menus_MenuId",
                table: "MenuPermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuPermissions_Users_UserId",
                table: "MenuPermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Menus_ParentMenuId",
                table: "Menus");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_DrugCatalogs_DrugCatalogId",
                table: "Prescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Invoices_MedicalExaminationId",
                table: "Prescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Receptions_Receptionists_ReceptionistId",
                table: "Receptions");

            migrationBuilder.DropTable(
                name: "DiagnosticImagingResultImages");

            migrationBuilder.DropTable(
                name: "Dictionaries");

            migrationBuilder.DropTable(
                name: "DoctorsCommonIcds");

            migrationBuilder.DropTable(
                name: "DocumentDetails");

            migrationBuilder.DropTable(
                name: "EinvoiceFiles");

            migrationBuilder.DropTable(
                name: "EmailAccounts");

            migrationBuilder.DropTable(
                name: "EmailContentImages");

            migrationBuilder.DropTable(
                name: "ExaminationConfirmations");

            migrationBuilder.DropTable(
                name: "LabTestFiles");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "PriceTypes");

            migrationBuilder.DropTable(
                name: "Receptionists");

            migrationBuilder.DropTable(
                name: "ReportParameters");

            migrationBuilder.DropTable(
                name: "ReportPermissions");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "TemplatePrescriptionDrugMappings");

            migrationBuilder.DropTable(
                name: "UserActionByMedicalRecords");

            migrationBuilder.DropTable(
                name: "UserActions");

            migrationBuilder.DropTable(
                name: "UserDepartments");

            migrationBuilder.DropTable(
                name: "UserPharmacies");

            migrationBuilder.DropTable(
                name: "ZaloUsers");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "TypeOfControlInputs");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "LoginSessions");

            migrationBuilder.DropTable(
                name: "DocumentPurposes");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_DrugCatalogId",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_MedicalExaminationId",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_MenuPermissions_MenuId",
                table: "MenuPermissions");

            migrationBuilder.DropIndex(
                name: "IX_MenuPermissions_UserId",
                table: "MenuPermissions");

            migrationBuilder.DropIndex(
                name: "IX_MedicalServiceRequests_AssignedById",
                table: "MedicalServiceRequests");

            migrationBuilder.DropIndex(
                name: "IX_DrugCatalogs_ManagementPharmacyId",
                table: "DrugCatalogs");

            migrationBuilder.DropIndex(
                name: "IX_DrugBookings_LoginSessionId",
                table: "DrugBookings");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PositionId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ReceptionNumber",
                table: "Receptions");

            migrationBuilder.DropColumn(
                name: "AfternoonDose",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "DaysOfSupply",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "DispensedQuantity",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "DrugCatalogId",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "EveningDose",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "IsDispensed",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "MorningDose",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "NoonDose",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "PrescriptionNumber",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "CostCenterId",
                table: "Pharmacies");

            migrationBuilder.DropColumn(
                name: "IsSourceManagement",
                table: "Pharmacies");

            migrationBuilder.DropColumn(
                name: "SpecialtyId",
                table: "Pharmacies");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "MenuPermissions");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MenuPermissions");

            migrationBuilder.DropColumn(
                name: "ExecutionDate",
                table: "MedicalServiceRequests");

            migrationBuilder.DropColumn(
                name: "ExecutionTime",
                table: "MedicalServiceRequests");

            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "MedicalServiceRequests");

            migrationBuilder.DropColumn(
                name: "NumberOfTubes",
                table: "MedicalServiceRequests");

            migrationBuilder.DropColumn(
                name: "RequestDate",
                table: "MedicalServiceRequests");

            migrationBuilder.DropColumn(
                name: "RequestNumber",
                table: "MedicalServiceRequests");

            migrationBuilder.DropColumn(
                name: "Result",
                table: "MedicalServiceRequests");

            migrationBuilder.DropColumn(
                name: "SampleCollectionDate",
                table: "MedicalServiceRequests");

            migrationBuilder.DropColumn(
                name: "SampleCollectionTime",
                table: "MedicalServiceRequests");

            migrationBuilder.DropColumn(
                name: "ServiceUnitPrice",
                table: "MedicalServiceRequests");

            migrationBuilder.DropColumn(
                name: "Sid",
                table: "MedicalServiceRequests");

            migrationBuilder.DropColumn(
                name: "Address1",
                table: "Hospitals");

            migrationBuilder.DropColumn(
                name: "Address2",
                table: "Hospitals");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ManagementPharmacyId",
                table: "DrugCatalogs");

            migrationBuilder.DropColumn(
                name: "NationalDrugCode",
                table: "DrugCatalogs");

            migrationBuilder.DropColumn(
                name: "LoginSessionId",
                table: "DrugBookings");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "NameRussian",
                table: "Suppliers",
                newName: "NameVietNam");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Menus",
                newName: "Path");

            migrationBuilder.RenameColumn(
                name: "MenuPermissionId",
                table: "MenuPermissions",
                newName: "MenuParentId");

            migrationBuilder.RenameColumn(
                name: "SampleCollectorId",
                table: "MedicalServiceRequests",
                newName: "ParentMedicalServiceRequestMedicalServiceRequestId");

            migrationBuilder.RenameColumn(
                name: "ParentMedicalServiceRequestId",
                table: "MedicalServiceRequests",
                newName: "ExamineId");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalServiceRequests_SampleCollectorId",
                table: "MedicalServiceRequests",
                newName: "IX_MedicalServiceRequests_ParentMedicalServiceRequestMedicalServiceRequestId");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalServiceRequests_ParentMedicalServiceRequestId",
                table: "MedicalServiceRequests",
                newName: "IX_MedicalServiceRequests_ExamineId");

            migrationBuilder.RenameColumn(
                name: "NameRussian",
                table: "Icdchapters",
                newName: "NameVietNamese");

            migrationBuilder.RenameColumn(
                name: "Address3",
                table: "Hospitals",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "HospitalId",
                table: "Hospitals",
                newName: "ClinicId");

            migrationBuilder.RenameColumn(
                name: "TitleId",
                table: "Employees",
                newName: "AvataId");

            migrationBuilder.RenameColumn(
                name: "MedicalExaminationId",
                table: "DrugBookings",
                newName: "ExamineId");

            migrationBuilder.RenameIndex(
                name: "IX_DrugBookings_MedicalExaminationId",
                table: "DrugBookings",
                newName: "IX_DrugBookings_ExamineId");

            migrationBuilder.RenameColumn(
                name: "MedicalExaminationId",
                table: "Appointments",
                newName: "ExaminationId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_MedicalExaminationId",
                table: "Appointments",
                newName: "IX_Appointments_ExaminationId");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "UnitOfMeasures",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "UnitOfMeasures",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DrugCatalogId",
                table: "TemplatePrescriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DistrictCode",
                table: "Suppliers",
                type: "nvarchar(20)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DistrictId",
                table: "Suppliers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProvinceCode",
                table: "Suppliers",
                type: "nvarchar(20)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProvinceId",
                table: "Suppliers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WardCode",
                table: "Suppliers",
                type: "nvarchar(20)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WardId",
                table: "Suppliers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServiceTypeId",
                table: "ServiceCatalogs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MedicalServiceRequestId",
                table: "Receptions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServiceTotalAmount",
                table: "Receptions",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "Prescriptions",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DistrictCode",
                table: "Patients",
                type: "nvarchar(20)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DistrictId",
                table: "Patients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Patients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProvinceCode",
                table: "Patients",
                type: "nvarchar(20)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProvinceId",
                table: "Patients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WardCode",
                table: "Patients",
                type: "nvarchar(20)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WardId",
                table: "Patients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserType",
                table: "MenuPermissions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "MedicalServiceRequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "MedicalServiceRequests",
                type: "bit",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AssignedByDoctorDoctorId",
                table: "MedicalServiceRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AssignedByEmployeeEmployeeId",
                table: "MedicalServiceRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DistrictCode",
                table: "Hospitals",
                type: "nvarchar(20)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DistrictId",
                table: "Hospitals",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProvinceCode",
                table: "Hospitals",
                type: "nvarchar(20)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProvinceId",
                table: "Hospitals",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WardCode",
                table: "Hospitals",
                type: "nvarchar(20)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WardId",
                table: "Hospitals",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DrugCatalogs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DrugCatalogs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DrugCatalogId",
                table: "DrugCatalogs",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "AvataId",
                table: "Doctors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConclusionDictionaryId",
                table: "DiagnosticImagingResults",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Conversations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Examines",
                columns: table => new
                {
                    ExamineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceptionId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RespiratoryRate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bmi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Symptoms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ICDCatalogId = table.Column<int>(type: "int", nullable: true),
                    DiagnosisDictionaryId = table.Column<int>(type: "int", nullable: true),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Conclusion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicalAdvice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrescriptionId = table.Column<int>(type: "int", nullable: true),
                    TemplatePrescriptionId = table.Column<int>(type: "int", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    PrescriptionNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FollowUpAppointment = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Comorbidities = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComorbidityCodes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComorbidityNames = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicalHistory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExaminationDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LabSummary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TreatmentDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FollowUpAppointmentNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonForVisit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExaminationNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examines", x => x.ExamineId);
                    table.ForeignKey(
                        name: "FK_Examines_DiagnosisDictionaries_DiagnosisDictionaryId",
                        column: x => x.DiagnosisDictionaryId,
                        principalTable: "DiagnosisDictionaries",
                        principalColumn: "DiagnosisDictionaryId");
                    table.ForeignKey(
                        name: "FK_Examines_ICDcatalogs_ICDCatalogId",
                        column: x => x.ICDCatalogId,
                        principalTable: "ICDcatalogs",
                        principalColumn: "ICDCatalogId");
                    table.ForeignKey(
                        name: "FK_Examines_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId");
                    table.ForeignKey(
                        name: "FK_Examines_Prescriptions_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescriptions",
                        principalColumn: "PrescriptionId");
                    table.ForeignKey(
                        name: "FK_Examines_Receptions_ReceptionId",
                        column: x => x.ReceptionId,
                        principalTable: "Receptions",
                        principalColumn: "ReceptionId");
                    table.ForeignKey(
                        name: "FK_Examines_TemplatePrescriptions_TemplatePrescriptionId",
                        column: x => x.TemplatePrescriptionId,
                        principalTable: "TemplatePrescriptions",
                        principalColumn: "TemplatePrescriptionId");
                });

            migrationBuilder.CreateTable(
                name: "PrescriptionDetail",
                columns: table => new
                {
                    PrescriptionDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrescriptionId = table.Column<int>(type: "int", nullable: false),
                    DrugCatalogId = table.Column<int>(type: "int", nullable: false),
                    MorningDose = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NoonDose = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AfternoonDose = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EveningDose = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DaysOfSupply = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescriptionDetail", x => x.PrescriptionDetailId);
                    table.ForeignKey(
                        name: "FK_PrescriptionDetail_DrugCatalogs_DrugCatalogId",
                        column: x => x.DrugCatalogId,
                        principalTable: "DrugCatalogs",
                        principalColumn: "DrugCatalogId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrescriptionDetail_Prescriptions_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescriptions",
                        principalColumn: "PrescriptionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTypes",
                columns: table => new
                {
                    ServiceTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTypes", x => x.ServiceTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ChatMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConversationId = table.Column<int>(type: "int", nullable: false),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatMessages_Conversations_ConversationId",
                        column: x => x.ConversationId,
                        principalTable: "Conversations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_DistrictCode",
                table: "Suppliers",
                column: "DistrictCode");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_ProvinceCode",
                table: "Suppliers",
                column: "ProvinceCode");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_WardCode",
                table: "Suppliers",
                column: "WardCode");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCatalogs_ServiceTypeId",
                table: "ServiceCatalogs",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_DistrictCode",
                table: "Patients",
                column: "DistrictCode");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_ImageId",
                table: "Patients",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_ProvinceCode",
                table: "Patients",
                column: "ProvinceCode");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_WardCode",
                table: "Patients",
                column: "WardCode");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalServiceRequests_AssignedByDoctorDoctorId",
                table: "MedicalServiceRequests",
                column: "AssignedByDoctorDoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalServiceRequests_AssignedByEmployeeEmployeeId",
                table: "MedicalServiceRequests",
                column: "AssignedByEmployeeEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Hospitals_DistrictCode",
                table: "Hospitals",
                column: "DistrictCode");

            migrationBuilder.CreateIndex(
                name: "IX_Hospitals_ProvinceCode",
                table: "Hospitals",
                column: "ProvinceCode");

            migrationBuilder.CreateIndex(
                name: "IX_Hospitals_WardCode",
                table: "Hospitals",
                column: "WardCode");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AvataId",
                table: "Employees",
                column: "AvataId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_AvataId",
                table: "Doctors",
                column: "AvataId");

            migrationBuilder.CreateIndex(
                name: "IX_DiagnosticImagingResults_ConclusionDictionaryId",
                table: "DiagnosticImagingResults",
                column: "ConclusionDictionaryId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DoctorId",
                table: "AspNetUsers",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EmployeeId",
                table: "AspNetUsers",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PatientId",
                table: "AspNetUsers",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_ConversationId",
                table: "ChatMessages",
                column: "ConversationId");

            migrationBuilder.CreateIndex(
                name: "IX_Examines_DiagnosisDictionaryId",
                table: "Examines",
                column: "DiagnosisDictionaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Examines_ICDCatalogId",
                table: "Examines",
                column: "ICDCatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_Examines_PatientId",
                table: "Examines",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Examines_PrescriptionId",
                table: "Examines",
                column: "PrescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Examines_ReceptionId",
                table: "Examines",
                column: "ReceptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Examines_TemplatePrescriptionId",
                table: "Examines",
                column: "TemplatePrescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionDetail_DrugCatalogId",
                table: "PrescriptionDetail",
                column: "DrugCatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionDetail_PrescriptionId",
                table: "PrescriptionDetail",
                column: "PrescriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Examines_ExaminationId",
                table: "Appointments",
                column: "ExaminationId",
                principalTable: "Examines",
                principalColumn: "ExamineId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Doctors_DoctorId",
                table: "AspNetUsers",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Employees_EmployeeId",
                table: "AspNetUsers",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Patients_PatientId",
                table: "AspNetUsers",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_DiagnosticImagingResults_ConclusionDictionaries_ConclusionDictionaryId",
                table: "DiagnosticImagingResults",
                column: "ConclusionDictionaryId",
                principalTable: "ConclusionDictionaries",
                principalColumn: "ConclusionDictionaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Savefiles_AvataId",
                table: "Doctors",
                column: "AvataId",
                principalTable: "Savefiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DrugBookings_Examines_ExamineId",
                table: "DrugBookings",
                column: "ExamineId",
                principalTable: "Examines",
                principalColumn: "ExamineId");

            migrationBuilder.AddForeignKey(
                name: "FK_DrugCatalogs_TemplatePrescriptions_DrugCatalogId",
                table: "DrugCatalogs",
                column: "DrugCatalogId",
                principalTable: "TemplatePrescriptions",
                principalColumn: "TemplatePrescriptionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Savefiles_AvataId",
                table: "Employees",
                column: "AvataId",
                principalTable: "Savefiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hospitals_Districts_DistrictCode",
                table: "Hospitals",
                column: "DistrictCode",
                principalTable: "Districts",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_Hospitals_Provinces_ProvinceCode",
                table: "Hospitals",
                column: "ProvinceCode",
                principalTable: "Provinces",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_Hospitals_Wards_WardCode",
                table: "Hospitals",
                column: "WardCode",
                principalTable: "Wards",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalServiceRequests_Doctors_AssignedByDoctorDoctorId",
                table: "MedicalServiceRequests",
                column: "AssignedByDoctorDoctorId",
                principalTable: "Doctors",
                principalColumn: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalServiceRequests_Employees_AssignedByEmployeeEmployeeId",
                table: "MedicalServiceRequests",
                column: "AssignedByEmployeeEmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalServiceRequests_Examines_ExamineId",
                table: "MedicalServiceRequests",
                column: "ExamineId",
                principalTable: "Examines",
                principalColumn: "ExamineId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalServiceRequests_MedicalServiceRequests_ParentMedicalServiceRequestMedicalServiceRequestId",
                table: "MedicalServiceRequests",
                column: "ParentMedicalServiceRequestMedicalServiceRequestId",
                principalTable: "MedicalServiceRequests",
                principalColumn: "MedicalServiceRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_MenuPermissions_ParentMenuId",
                table: "Menus",
                column: "ParentMenuId",
                principalTable: "MenuPermissions",
                principalColumn: "MenuParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Districts_DistrictCode",
                table: "Patients",
                column: "DistrictCode",
                principalTable: "Districts",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Provinces_ProvinceCode",
                table: "Patients",
                column: "ProvinceCode",
                principalTable: "Provinces",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Savefiles_ImageId",
                table: "Patients",
                column: "ImageId",
                principalTable: "Savefiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Wards_WardCode",
                table: "Patients",
                column: "WardCode",
                principalTable: "Wards",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_Receptions_Employees_ReceptionistId",
                table: "Receptions",
                column: "ReceptionistId",
                principalTable: "Employees",
                principalColumn: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceCatalogs_ServiceTypes_ServiceTypeId",
                table: "ServiceCatalogs",
                column: "ServiceTypeId",
                principalTable: "ServiceTypes",
                principalColumn: "ServiceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Districts_DistrictCode",
                table: "Suppliers",
                column: "DistrictCode",
                principalTable: "Districts",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Provinces_ProvinceCode",
                table: "Suppliers",
                column: "ProvinceCode",
                principalTable: "Provinces",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Wards_WardCode",
                table: "Suppliers",
                column: "WardCode",
                principalTable: "Wards",
                principalColumn: "Code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Examines_ExaminationId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Doctors_DoctorId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Employees_EmployeeId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Patients_PatientId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_DiagnosticImagingResults_ConclusionDictionaries_ConclusionDictionaryId",
                table: "DiagnosticImagingResults");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Savefiles_AvataId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_DrugBookings_Examines_ExamineId",
                table: "DrugBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_DrugCatalogs_TemplatePrescriptions_DrugCatalogId",
                table: "DrugCatalogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Savefiles_AvataId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Hospitals_Districts_DistrictCode",
                table: "Hospitals");

            migrationBuilder.DropForeignKey(
                name: "FK_Hospitals_Provinces_ProvinceCode",
                table: "Hospitals");

            migrationBuilder.DropForeignKey(
                name: "FK_Hospitals_Wards_WardCode",
                table: "Hospitals");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalServiceRequests_Doctors_AssignedByDoctorDoctorId",
                table: "MedicalServiceRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalServiceRequests_Employees_AssignedByEmployeeEmployeeId",
                table: "MedicalServiceRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalServiceRequests_Examines_ExamineId",
                table: "MedicalServiceRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalServiceRequests_MedicalServiceRequests_ParentMedicalServiceRequestMedicalServiceRequestId",
                table: "MedicalServiceRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Menus_MenuPermissions_ParentMenuId",
                table: "Menus");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Districts_DistrictCode",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Provinces_ProvinceCode",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Savefiles_ImageId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Wards_WardCode",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Receptions_Employees_ReceptionistId",
                table: "Receptions");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceCatalogs_ServiceTypes_ServiceTypeId",
                table: "ServiceCatalogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Districts_DistrictCode",
                table: "Suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Provinces_ProvinceCode",
                table: "Suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Wards_WardCode",
                table: "Suppliers");

            migrationBuilder.DropTable(
                name: "ChatMessages");

            migrationBuilder.DropTable(
                name: "Examines");

            migrationBuilder.DropTable(
                name: "PrescriptionDetail");

            migrationBuilder.DropTable(
                name: "ServiceTypes");

            migrationBuilder.DropTable(
                name: "Conversations");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_DistrictCode",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_ProvinceCode",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_WardCode",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_ServiceCatalogs_ServiceTypeId",
                table: "ServiceCatalogs");

            migrationBuilder.DropIndex(
                name: "IX_Patients_DistrictCode",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_ImageId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_ProvinceCode",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_WardCode",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_MedicalServiceRequests_AssignedByDoctorDoctorId",
                table: "MedicalServiceRequests");

            migrationBuilder.DropIndex(
                name: "IX_MedicalServiceRequests_AssignedByEmployeeEmployeeId",
                table: "MedicalServiceRequests");

            migrationBuilder.DropIndex(
                name: "IX_Hospitals_DistrictCode",
                table: "Hospitals");

            migrationBuilder.DropIndex(
                name: "IX_Hospitals_ProvinceCode",
                table: "Hospitals");

            migrationBuilder.DropIndex(
                name: "IX_Hospitals_WardCode",
                table: "Hospitals");

            migrationBuilder.DropIndex(
                name: "IX_Employees_AvataId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_AvataId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_DiagnosticImagingResults_ConclusionDictionaryId",
                table: "DiagnosticImagingResults");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DoctorId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_EmployeeId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PatientId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DrugCatalogId",
                table: "TemplatePrescriptions");

            migrationBuilder.DropColumn(
                name: "DistrictCode",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "ProvinceCode",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "WardCode",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "WardId",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "ServiceTypeId",
                table: "ServiceCatalogs");

            migrationBuilder.DropColumn(
                name: "MedicalServiceRequestId",
                table: "Receptions");

            migrationBuilder.DropColumn(
                name: "ServiceTotalAmount",
                table: "Receptions");

            migrationBuilder.DropColumn(
                name: "DistrictCode",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "ProvinceCode",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "WardCode",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "WardId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "UserType",
                table: "MenuPermissions");

            migrationBuilder.DropColumn(
                name: "AssignedByDoctorDoctorId",
                table: "MedicalServiceRequests");

            migrationBuilder.DropColumn(
                name: "AssignedByEmployeeEmployeeId",
                table: "MedicalServiceRequests");

            migrationBuilder.DropColumn(
                name: "DistrictCode",
                table: "Hospitals");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "Hospitals");

            migrationBuilder.DropColumn(
                name: "ProvinceCode",
                table: "Hospitals");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                table: "Hospitals");

            migrationBuilder.DropColumn(
                name: "WardCode",
                table: "Hospitals");

            migrationBuilder.DropColumn(
                name: "WardId",
                table: "Hospitals");

            migrationBuilder.DropColumn(
                name: "AvataId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "ConclusionDictionaryId",
                table: "DiagnosticImagingResults");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "NameVietNam",
                table: "Suppliers",
                newName: "NameRussian");

            migrationBuilder.RenameColumn(
                name: "Path",
                table: "Menus",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "MenuParentId",
                table: "MenuPermissions",
                newName: "MenuPermissionId");

            migrationBuilder.RenameColumn(
                name: "ParentMedicalServiceRequestMedicalServiceRequestId",
                table: "MedicalServiceRequests",
                newName: "SampleCollectorId");

            migrationBuilder.RenameColumn(
                name: "ExamineId",
                table: "MedicalServiceRequests",
                newName: "ParentMedicalServiceRequestId");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalServiceRequests_ParentMedicalServiceRequestMedicalServiceRequestId",
                table: "MedicalServiceRequests",
                newName: "IX_MedicalServiceRequests_SampleCollectorId");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalServiceRequests_ExamineId",
                table: "MedicalServiceRequests",
                newName: "IX_MedicalServiceRequests_ParentMedicalServiceRequestId");

            migrationBuilder.RenameColumn(
                name: "NameVietNamese",
                table: "Icdchapters",
                newName: "NameRussian");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Hospitals",
                newName: "Address3");

            migrationBuilder.RenameColumn(
                name: "ClinicId",
                table: "Hospitals",
                newName: "HospitalId");

            migrationBuilder.RenameColumn(
                name: "AvataId",
                table: "Employees",
                newName: "TitleId");

            migrationBuilder.RenameColumn(
                name: "ExamineId",
                table: "DrugBookings",
                newName: "MedicalExaminationId");

            migrationBuilder.RenameIndex(
                name: "IX_DrugBookings_ExamineId",
                table: "DrugBookings",
                newName: "IX_DrugBookings_MedicalExaminationId");

            migrationBuilder.RenameColumn(
                name: "ExaminationId",
                table: "Appointments",
                newName: "MedicalExaminationId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_ExaminationId",
                table: "Appointments",
                newName: "IX_Appointments_MedicalExaminationId");

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "UnitOfMeasures",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "UnitOfMeasures",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "Suppliers",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Suppliers",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReceptionNumber",
                table: "Receptions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "Prescriptions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "AfternoonDose",
                table: "Prescriptions",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DaysOfSupply",
                table: "Prescriptions",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DispensedQuantity",
                table: "Prescriptions",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DrugCatalogId",
                table: "Prescriptions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "EveningDose",
                table: "Prescriptions",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDispensed",
                table: "Prescriptions",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MorningDose",
                table: "Prescriptions",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "NoonDose",
                table: "Prescriptions",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrescriptionNumber",
                table: "Prescriptions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Quantity",
                table: "Prescriptions",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice",
                table: "Prescriptions",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CostCenterId",
                table: "Pharmacies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSourceManagement",
                table: "Pharmacies",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpecialtyId",
                table: "Pharmacies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "MenuPermissions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "MenuPermissions",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "MedicalServiceRequests",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "MedicalServiceRequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExecutionDate",
                table: "MedicalServiceRequests",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExecutionTime",
                table: "MedicalServiceRequests",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "MedicalServiceRequests",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumberOfTubes",
                table: "MedicalServiceRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RequestDate",
                table: "MedicalServiceRequests",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequestNumber",
                table: "MedicalServiceRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Result",
                table: "MedicalServiceRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SampleCollectionDate",
                table: "MedicalServiceRequests",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SampleCollectionTime",
                table: "MedicalServiceRequests",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ServiceUnitPrice",
                table: "MedicalServiceRequests",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sid",
                table: "MedicalServiceRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address1",
                table: "Hospitals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address2",
                table: "Hospitals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "DrugCatalogs",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "DrugCatalogs",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DrugCatalogId",
                table: "DrugCatalogs",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ManagementPharmacyId",
                table: "DrugCatalogs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NationalDrugCode",
                table: "DrugCatalogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginSessionId",
                table: "DrugBookings",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "Countries",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Countries",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DiagnosticImagingResultImages",
                columns: table => new
                {
                    DiagnosticImagingResultImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiagnosticImagingResultId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiagnosticImagingResultImages", x => x.DiagnosticImagingResultImageId);
                    table.ForeignKey(
                        name: "FK_DiagnosticImagingResultImages_DiagnosticImagingResults_DiagnosticImagingResultId",
                        column: x => x.DiagnosticImagingResultId,
                        principalTable: "DiagnosticImagingResults",
                        principalColumn: "DiagnosticImagingResultId");
                });

            migrationBuilder.CreateTable(
                name: "Dictionaries",
                columns: table => new
                {
                    DictionaryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<int>(type: "int", nullable: true),
                    IsSuspended = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameId = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dictionaries", x => x.DictionaryId);
                });

            migrationBuilder.CreateTable(
                name: "DoctorsCommonIcds",
                columns: table => new
                {
                    DoctorsCommonIcdid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    ICDCatalogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorsCommonIcds", x => x.DoctorsCommonIcdid);
                    table.ForeignKey(
                        name: "FK_DoctorsCommonIcds_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorsCommonIcds_ICDcatalogs_ICDCatalogId",
                        column: x => x.ICDCatalogId,
                        principalTable: "ICDcatalogs",
                        principalColumn: "ICDCatalogId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentPurposes",
                columns: table => new
                {
                    DocumentPurposeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentPurposes", x => x.DocumentPurposeId);
                });

            migrationBuilder.CreateTable(
                name: "EmailAccounts",
                columns: table => new
                {
                    EmailAccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<int>(type: "int", nullable: true),
                    IsSuspended = table.Column<int>(type: "int", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailAccounts", x => x.EmailAccountId);
                });

            migrationBuilder.CreateTable(
                name: "EmailContentImages",
                columns: table => new
                {
                    EmailContentImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailContentId = table.Column<int>(type: "int", nullable: true),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailContentImages", x => x.EmailContentImageId);
                    table.ForeignKey(
                        name: "FK_EmailContentImages_EmailContents_EmailContentId",
                        column: x => x.EmailContentId,
                        principalTable: "EmailContents",
                        principalColumn: "EmailContentId");
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ICDCatalogId = table.Column<int>(type: "int", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: true),
                    ReceptionId = table.Column<int>(type: "int", nullable: true),
                    Bmi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comorbidities = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComorbidityCodes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComorbidityNames = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Conclusion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExaminationDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExaminationNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FollowUpAppointment = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FollowUpAppointmentNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<int>(type: "int", nullable: true),
                    LabSummary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicalAdvice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicalExaminationId = table.Column<int>(type: "int", nullable: false),
                    MedicalHistory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrescriptionNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonForVisit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RespiratoryRate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Symptoms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TreatmentDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VatinvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_Invoices_ICDcatalogs_ICDCatalogId",
                        column: x => x.ICDCatalogId,
                        principalTable: "ICDcatalogs",
                        principalColumn: "ICDCatalogId");
                    table.ForeignKey(
                        name: "FK_Invoices_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId");
                    table.ForeignKey(
                        name: "FK_Invoices_Receptions_ReceptionId",
                        column: x => x.ReceptionId,
                        principalTable: "Receptions",
                        principalColumn: "ReceptionId");
                });

            migrationBuilder.CreateTable(
                name: "LabTestFiles",
                columns: table => new
                {
                    LabTestFileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: true),
                    ReceptionId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabTestFiles", x => x.LabTestFileId);
                    table.ForeignKey(
                        name: "FK_LabTestFiles_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LabTestFiles_Receptions_ReceptionId",
                        column: x => x.ReceptionId,
                        principalTable: "Receptions",
                        principalColumn: "ReceptionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PriceTypes",
                columns: table => new
                {
                    PriceTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceTypes", x => x.PriceTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Receptionists",
                columns: table => new
                {
                    ReceptionistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<int>(type: "int", nullable: true),
                    IsSuspended = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receptionists", x => x.ReceptionistId);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    ReportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<int>(type: "int", nullable: true),
                    IsSuspended = table.Column<int>(type: "int", nullable: true),
                    ProcedureName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.ReportId);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    SettingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Date1 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Date2 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<int>(type: "int", nullable: true),
                    IsSuspended = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number1 = table.Column<int>(type: "int", nullable: true),
                    Number2 = table.Column<int>(type: "int", nullable: true),
                    String1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    String2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.SettingId);
                });

            migrationBuilder.CreateTable(
                name: "TemplatePrescriptionDrugMappings",
                columns: table => new
                {
                    TemplatePrescriptionDrugMappingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrugCatalogId = table.Column<int>(type: "int", nullable: true),
                    TemplatePrescriptionId = table.Column<int>(type: "int", nullable: true),
                    AfternoonDose = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DaysOfSupply = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EveningDose = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsDeleted = table.Column<int>(type: "int", nullable: true),
                    MorningDose = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NoonDose = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplatePrescriptionDrugMappings", x => x.TemplatePrescriptionDrugMappingId);
                    table.ForeignKey(
                        name: "FK_TemplatePrescriptionDrugMappings_DrugCatalogs_DrugCatalogId",
                        column: x => x.DrugCatalogId,
                        principalTable: "DrugCatalogs",
                        principalColumn: "DrugCatalogId");
                    table.ForeignKey(
                        name: "FK_TemplatePrescriptionDrugMappings_TemplatePrescriptions_TemplatePrescriptionId",
                        column: x => x.TemplatePrescriptionId,
                        principalTable: "TemplatePrescriptions",
                        principalColumn: "TemplatePrescriptionId");
                });

            migrationBuilder.CreateTable(
                name: "TypeOfControlInputs",
                columns: table => new
                {
                    TypeOfControlInputId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfControlInputs", x => x.TypeOfControlInputId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HospitalId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<int>(type: "int", nullable: true),
                    IsSuspended = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Hospitals_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "Hospitals",
                        principalColumn: "HospitalId");
                });

            migrationBuilder.CreateTable(
                name: "ZaloUsers",
                columns: table => new
                {
                    RowNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserIdByApp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZaloUsers", x => x.RowNumber);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    DocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApproverId = table.Column<int>(type: "int", nullable: true),
                    ChiefAccountantId = table.Column<int>(type: "int", nullable: true),
                    CorrespondingPharmacyId = table.Column<int>(type: "int", nullable: true),
                    DelivererId = table.Column<int>(type: "int", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    DoctorId = table.Column<int>(type: "int", nullable: true),
                    DocumentPurposeId = table.Column<int>(type: "int", nullable: true),
                    ExecutionPharmacyId = table.Column<int>(type: "int", nullable: true),
                    InputterId = table.Column<int>(type: "int", nullable: true),
                    InspectorId = table.Column<int>(type: "int", nullable: true),
                    IssuingPharmacyId = table.Column<int>(type: "int", nullable: true),
                    MedicalExaminationId = table.Column<int>(type: "int", nullable: true),
                    ReceiverId = table.Column<int>(type: "int", nullable: true),
                    ReceivingPharmacyId = table.Column<int>(type: "int", nullable: true),
                    ReferralDoctorId = table.Column<int>(type: "int", nullable: true),
                    RelatedDocumentId = table.Column<int>(type: "int", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    TreasurerId = table.Column<int>(type: "int", nullable: true),
                    UsagePharmacyId = table.Column<int>(type: "int", nullable: true),
                    AccountingDocument = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreditAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrencyId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebitAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeductibleRequisitionFormId = table.Column<int>(type: "int", nullable: true),
                    DeliveryUnitId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DiscountRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DocumentCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocumentNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentStatus = table.Column<int>(type: "int", nullable: true),
                    DocumentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DrugSourceId = table.Column<int>(type: "int", nullable: true),
                    ExchangeRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ForeignInvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ForeignInvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForeignSerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GeneratedTransactionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasReceivedMedication = table.Column<bool>(type: "bit", nullable: false),
                    ImportVatamount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ImportVatrate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    InpatientPrescriptionId = table.Column<int>(type: "int", nullable: true),
                    InputDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<int>(type: "int", nullable: true),
                    IsHealthInsurance = table.Column<bool>(type: "bit", nullable: true),
                    IsHospitalFee = table.Column<bool>(type: "bit", nullable: true),
                    MaterialTypeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicalRecordId = table.Column<int>(type: "int", nullable: true),
                    OriginalDocumentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OriginalDocumentNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: true),
                    PaymentValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ReferenceDocumentCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenceDocumentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequisitionFormId = table.Column<int>(type: "int", nullable: true),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TargetObjectId = table.Column<int>(type: "int", nullable: true),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TaxRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TransferId = table.Column<int>(type: "int", nullable: true),
                    TransferPaymentId = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Vatamount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Vatrate = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.DocumentId);
                    table.ForeignKey(
                        name: "FK_Documents_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId");
                    table.ForeignKey(
                        name: "FK_Documents_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId");
                    table.ForeignKey(
                        name: "FK_Documents_Doctors_ReferralDoctorId",
                        column: x => x.ReferralDoctorId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId");
                    table.ForeignKey(
                        name: "FK_Documents_DocumentPurposes_DocumentPurposeId",
                        column: x => x.DocumentPurposeId,
                        principalTable: "DocumentPurposes",
                        principalColumn: "DocumentPurposeId");
                    table.ForeignKey(
                        name: "FK_Documents_Documents_RelatedDocumentId",
                        column: x => x.RelatedDocumentId,
                        principalTable: "Documents",
                        principalColumn: "DocumentId");
                    table.ForeignKey(
                        name: "FK_Documents_Employees_ApproverId",
                        column: x => x.ApproverId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_Documents_Employees_ChiefAccountantId",
                        column: x => x.ChiefAccountantId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_Documents_Employees_DelivererId",
                        column: x => x.DelivererId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_Documents_Employees_InputterId",
                        column: x => x.InputterId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_Documents_Employees_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_Documents_Employees_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_Documents_Employees_TreasurerId",
                        column: x => x.TreasurerId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_Documents_Invoices_MedicalExaminationId",
                        column: x => x.MedicalExaminationId,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceId");
                    table.ForeignKey(
                        name: "FK_Documents_Pharmacies_CorrespondingPharmacyId",
                        column: x => x.CorrespondingPharmacyId,
                        principalTable: "Pharmacies",
                        principalColumn: "PharmacyId");
                    table.ForeignKey(
                        name: "FK_Documents_Pharmacies_ExecutionPharmacyId",
                        column: x => x.ExecutionPharmacyId,
                        principalTable: "Pharmacies",
                        principalColumn: "PharmacyId");
                    table.ForeignKey(
                        name: "FK_Documents_Pharmacies_IssuingPharmacyId",
                        column: x => x.IssuingPharmacyId,
                        principalTable: "Pharmacies",
                        principalColumn: "PharmacyId");
                    table.ForeignKey(
                        name: "FK_Documents_Pharmacies_ReceivingPharmacyId",
                        column: x => x.ReceivingPharmacyId,
                        principalTable: "Pharmacies",
                        principalColumn: "PharmacyId");
                    table.ForeignKey(
                        name: "FK_Documents_Pharmacies_UsagePharmacyId",
                        column: x => x.UsagePharmacyId,
                        principalTable: "Pharmacies",
                        principalColumn: "PharmacyId");
                    table.ForeignKey(
                        name: "FK_Documents_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId");
                });

            migrationBuilder.CreateTable(
                name: "EinvoiceFiles",
                columns: table => new
                {
                    EinvoiceFileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<int>(type: "int", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EinvoiceFiles", x => x.EinvoiceFileId);
                    table.ForeignKey(
                        name: "FK_EinvoiceFiles_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceId");
                    table.ForeignKey(
                        name: "FK_EinvoiceFiles_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId");
                });

            migrationBuilder.CreateTable(
                name: "ExaminationConfirmations",
                columns: table => new
                {
                    ExaminationConfirmationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicalExaminationId = table.Column<int>(type: "int", nullable: true),
                    MedicalExaminationInvoiceId = table.Column<int>(type: "int", nullable: true),
                    ReceptionId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExaminationConfirmations", x => x.ExaminationConfirmationId);
                    table.ForeignKey(
                        name: "FK_ExaminationConfirmations_Invoices_MedicalExaminationId",
                        column: x => x.MedicalExaminationId,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExaminationConfirmations_Invoices_MedicalExaminationInvoiceId",
                        column: x => x.MedicalExaminationInvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceId");
                    table.ForeignKey(
                        name: "FK_ExaminationConfirmations_Receptions_ReceptionId",
                        column: x => x.ReceptionId,
                        principalTable: "Receptions",
                        principalColumn: "ReceptionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReportParameters",
                columns: table => new
                {
                    ReportParameterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportId = table.Column<int>(type: "int", nullable: false),
                    TypeOfControlInputId = table.Column<int>(type: "int", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemType = table.Column<int>(type: "int", nullable: true),
                    LoadType = table.Column<int>(type: "int", nullable: true),
                    NumericalOrder = table.Column<int>(type: "int", nullable: true),
                    ParameterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValueIntCheckBoxFalse = table.Column<int>(type: "int", nullable: true),
                    ValueIntCheckBoxTrue = table.Column<int>(type: "int", nullable: true),
                    ValueStringCheckBoxFalse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValueStringCheckBoxTrue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportParameters", x => x.ReportParameterId);
                    table.ForeignKey(
                        name: "FK_ReportParameters_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "ReportId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReportParameters_TypeOfControlInputs_TypeOfControlInputId",
                        column: x => x.TypeOfControlInputId,
                        principalTable: "TypeOfControlInputs",
                        principalColumn: "TypeOfControlInputId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LoginSessions",
                columns: table => new
                {
                    LoginSessionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    PharmacyId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Ipaddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LogoutTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Macaddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginSessions", x => x.LoginSessionId);
                    table.ForeignKey(
                        name: "FK_LoginSessions_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId");
                    table.ForeignKey(
                        name: "FK_LoginSessions_Pharmacies_PharmacyId",
                        column: x => x.PharmacyId,
                        principalTable: "Pharmacies",
                        principalColumn: "PharmacyId");
                    table.ForeignKey(
                        name: "FK_LoginSessions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "ReportPermissions",
                columns: table => new
                {
                    ReportPermissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportPermissions", x => x.ReportPermissionId);
                    table.ForeignKey(
                        name: "FK_ReportPermissions_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "ReportId");
                    table.ForeignKey(
                        name: "FK_ReportPermissions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "UserDepartments",
                columns: table => new
                {
                    UserDepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDepartments", x => x.UserDepartmentId);
                    table.ForeignKey(
                        name: "FK_UserDepartments_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId");
                    table.ForeignKey(
                        name: "FK_UserDepartments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "UserPharmacies",
                columns: table => new
                {
                    UserPharmacyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PharmacyId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPharmacies", x => x.UserPharmacyId);
                    table.ForeignKey(
                        name: "FK_UserPharmacies_Pharmacies_PharmacyId",
                        column: x => x.PharmacyId,
                        principalTable: "Pharmacies",
                        principalColumn: "PharmacyId");
                    table.ForeignKey(
                        name: "FK_UserPharmacies_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "DocumentDetails",
                columns: table => new
                {
                    DocumentDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentId = table.Column<int>(type: "int", nullable: false),
                    DrugCatalogId = table.Column<int>(type: "int", nullable: false),
                    OriginalUnitOfMeasureId = table.Column<int>(type: "int", nullable: true),
                    UnitOfMeasureId = table.Column<int>(type: "int", nullable: true),
                    AccountingDocumentNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActualQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BookNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CashDocumentNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ControlNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CostPriceIncludingVat = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CurrencyId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExchangeRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FreeReasonId = table.Column<int>(type: "int", nullable: true),
                    HasGeneratedIssueDocument = table.Column<bool>(type: "bit", nullable: false),
                    HasGeneratedReturnDocument = table.Column<bool>(type: "bit", nullable: false),
                    ImportLotNumberId = table.Column<int>(type: "int", nullable: true),
                    IsFree = table.Column<bool>(type: "bit", nullable: false),
                    IsLotSplit = table.Column<bool>(type: "bit", nullable: true),
                    IsPromotion = table.Column<bool>(type: "bit", nullable: false),
                    IssuedQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    OriginalQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PaymentPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RequestedQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SellingPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SourceId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalCostAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalPurchaseAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Vatamount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VatinvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vatrate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VisaNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentDetails", x => x.DocumentDetailId);
                    table.ForeignKey(
                        name: "FK_DocumentDetails_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentDetails_DrugCatalogs_DrugCatalogId",
                        column: x => x.DrugCatalogId,
                        principalTable: "DrugCatalogs",
                        principalColumn: "DrugCatalogId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentDetails_UnitOfMeasures_OriginalUnitOfMeasureId",
                        column: x => x.OriginalUnitOfMeasureId,
                        principalTable: "UnitOfMeasures",
                        principalColumn: "UnitOfMeasureId");
                    table.ForeignKey(
                        name: "FK_DocumentDetails_UnitOfMeasures_UnitOfMeasureId",
                        column: x => x.UnitOfMeasureId,
                        principalTable: "UnitOfMeasures",
                        principalColumn: "UnitOfMeasureId");
                });

            migrationBuilder.CreateTable(
                name: "UserActionByMedicalRecords",
                columns: table => new
                {
                    UserActionByMedicalRecordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoginSessionId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AdmissionNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicalRecordNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserActionByMedicalRecords", x => x.UserActionByMedicalRecordId);
                    table.ForeignKey(
                        name: "FK_UserActionByMedicalRecords_LoginSessions_LoginSessionId",
                        column: x => x.LoginSessionId,
                        principalTable: "LoginSessions",
                        principalColumn: "LoginSessionId");
                    table.ForeignKey(
                        name: "FK_UserActionByMedicalRecords_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "UserActions",
                columns: table => new
                {
                    UserActionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoginSessionId = table.Column<int>(type: "int", nullable: true),
                    ServiceId = table.Column<int>(type: "int", nullable: true),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestObjectId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserActions", x => x.UserActionId);
                    table.ForeignKey(
                        name: "FK_UserActions_LoginSessions_LoginSessionId",
                        column: x => x.LoginSessionId,
                        principalTable: "LoginSessions",
                        principalColumn: "LoginSessionId");
                    table.ForeignKey(
                        name: "FK_UserActions_ServiceCatalogs_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "ServiceCatalogs",
                        principalColumn: "ServiceCatalogId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_DrugCatalogId",
                table: "Prescriptions",
                column: "DrugCatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_MedicalExaminationId",
                table: "Prescriptions",
                column: "MedicalExaminationId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuPermissions_MenuId",
                table: "MenuPermissions",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuPermissions_UserId",
                table: "MenuPermissions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalServiceRequests_AssignedById",
                table: "MedicalServiceRequests",
                column: "AssignedById");

            migrationBuilder.CreateIndex(
                name: "IX_DrugCatalogs_ManagementPharmacyId",
                table: "DrugCatalogs",
                column: "ManagementPharmacyId");

            migrationBuilder.CreateIndex(
                name: "IX_DrugBookings_LoginSessionId",
                table: "DrugBookings",
                column: "LoginSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PositionId",
                table: "AspNetUsers",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_DiagnosticImagingResultImages_DiagnosticImagingResultId",
                table: "DiagnosticImagingResultImages",
                column: "DiagnosticImagingResultId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorsCommonIcds_DoctorId",
                table: "DoctorsCommonIcds",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorsCommonIcds_ICDCatalogId",
                table: "DoctorsCommonIcds",
                column: "ICDCatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentDetails_DocumentId",
                table: "DocumentDetails",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentDetails_DrugCatalogId",
                table: "DocumentDetails",
                column: "DrugCatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentDetails_OriginalUnitOfMeasureId",
                table: "DocumentDetails",
                column: "OriginalUnitOfMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentDetails_UnitOfMeasureId",
                table: "DocumentDetails",
                column: "UnitOfMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ApproverId",
                table: "Documents",
                column: "ApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ChiefAccountantId",
                table: "Documents",
                column: "ChiefAccountantId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_CorrespondingPharmacyId",
                table: "Documents",
                column: "CorrespondingPharmacyId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_DelivererId",
                table: "Documents",
                column: "DelivererId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_DepartmentId",
                table: "Documents",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_DoctorId",
                table: "Documents",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_DocumentPurposeId",
                table: "Documents",
                column: "DocumentPurposeId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ExecutionPharmacyId",
                table: "Documents",
                column: "ExecutionPharmacyId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_InputterId",
                table: "Documents",
                column: "InputterId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_InspectorId",
                table: "Documents",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_IssuingPharmacyId",
                table: "Documents",
                column: "IssuingPharmacyId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_MedicalExaminationId",
                table: "Documents",
                column: "MedicalExaminationId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ReceiverId",
                table: "Documents",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ReceivingPharmacyId",
                table: "Documents",
                column: "ReceivingPharmacyId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ReferralDoctorId",
                table: "Documents",
                column: "ReferralDoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_RelatedDocumentId",
                table: "Documents",
                column: "RelatedDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_SupplierId",
                table: "Documents",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_TreasurerId",
                table: "Documents",
                column: "TreasurerId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_UsagePharmacyId",
                table: "Documents",
                column: "UsagePharmacyId");

            migrationBuilder.CreateIndex(
                name: "IX_EinvoiceFiles_InvoiceId",
                table: "EinvoiceFiles",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_EinvoiceFiles_PatientId",
                table: "EinvoiceFiles",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailContentImages_EmailContentId",
                table: "EmailContentImages",
                column: "EmailContentId");

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationConfirmations_MedicalExaminationId",
                table: "ExaminationConfirmations",
                column: "MedicalExaminationId");

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationConfirmations_MedicalExaminationInvoiceId",
                table: "ExaminationConfirmations",
                column: "MedicalExaminationInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationConfirmations_ReceptionId",
                table: "ExaminationConfirmations",
                column: "ReceptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ICDCatalogId",
                table: "Invoices",
                column: "ICDCatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_PatientId",
                table: "Invoices",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ReceptionId",
                table: "Invoices",
                column: "ReceptionId");

            migrationBuilder.CreateIndex(
                name: "IX_LabTestFiles_PatientId",
                table: "LabTestFiles",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_LabTestFiles_ReceptionId",
                table: "LabTestFiles",
                column: "ReceptionId");

            migrationBuilder.CreateIndex(
                name: "IX_LoginSessions_DepartmentId",
                table: "LoginSessions",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_LoginSessions_PharmacyId",
                table: "LoginSessions",
                column: "PharmacyId");

            migrationBuilder.CreateIndex(
                name: "IX_LoginSessions_UserId",
                table: "LoginSessions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportParameters_ReportId",
                table: "ReportParameters",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportParameters_TypeOfControlInputId",
                table: "ReportParameters",
                column: "TypeOfControlInputId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportPermissions_ReportId",
                table: "ReportPermissions",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportPermissions_UserId",
                table: "ReportPermissions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplatePrescriptionDrugMappings_DrugCatalogId",
                table: "TemplatePrescriptionDrugMappings",
                column: "DrugCatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplatePrescriptionDrugMappings_TemplatePrescriptionId",
                table: "TemplatePrescriptionDrugMappings",
                column: "TemplatePrescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserActionByMedicalRecords_LoginSessionId",
                table: "UserActionByMedicalRecords",
                column: "LoginSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserActionByMedicalRecords_UserId",
                table: "UserActionByMedicalRecords",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserActions_LoginSessionId",
                table: "UserActions",
                column: "LoginSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserActions_ServiceId",
                table: "UserActions",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDepartments_DepartmentId",
                table: "UserDepartments",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDepartments_UserId",
                table: "UserDepartments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPharmacies_PharmacyId",
                table: "UserPharmacies",
                column: "PharmacyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPharmacies_UserId",
                table: "UserPharmacies",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_HospitalId",
                table: "Users",
                column: "HospitalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Invoices_MedicalExaminationId",
                table: "Appointments",
                column: "MedicalExaminationId",
                principalTable: "Invoices",
                principalColumn: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Positions_PositionId",
                table: "AspNetUsers",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DrugBookings_Invoices_MedicalExaminationId",
                table: "DrugBookings",
                column: "MedicalExaminationId",
                principalTable: "Invoices",
                principalColumn: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_DrugBookings_LoginSessions_LoginSessionId",
                table: "DrugBookings",
                column: "LoginSessionId",
                principalTable: "LoginSessions",
                principalColumn: "LoginSessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_DrugCatalogs_Pharmacies_ManagementPharmacyId",
                table: "DrugCatalogs",
                column: "ManagementPharmacyId",
                principalTable: "Pharmacies",
                principalColumn: "PharmacyId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalServiceRequests_Employees_AssignedById",
                table: "MedicalServiceRequests",
                column: "AssignedById",
                principalTable: "Employees",
                principalColumn: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalServiceRequests_Employees_SampleCollectorId",
                table: "MedicalServiceRequests",
                column: "SampleCollectorId",
                principalTable: "Employees",
                principalColumn: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalServiceRequests_MedicalServiceRequests_ParentMedicalServiceRequestId",
                table: "MedicalServiceRequests",
                column: "ParentMedicalServiceRequestId",
                principalTable: "MedicalServiceRequests",
                principalColumn: "MedicalServiceRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuPermissions_Menus_MenuId",
                table: "MenuPermissions",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuPermissions_Users_UserId",
                table: "MenuPermissions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Menus_ParentMenuId",
                table: "Menus",
                column: "ParentMenuId",
                principalTable: "Menus",
                principalColumn: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_DrugCatalogs_DrugCatalogId",
                table: "Prescriptions",
                column: "DrugCatalogId",
                principalTable: "DrugCatalogs",
                principalColumn: "DrugCatalogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Invoices_MedicalExaminationId",
                table: "Prescriptions",
                column: "MedicalExaminationId",
                principalTable: "Invoices",
                principalColumn: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receptions_Receptionists_ReceptionistId",
                table: "Receptions",
                column: "ReceptionistId",
                principalTable: "Receptionists",
                principalColumn: "ReceptionistId");
        }
    }
}

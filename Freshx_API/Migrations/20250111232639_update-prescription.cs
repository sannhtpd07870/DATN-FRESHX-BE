using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Freshx_API.Migrations
{
    /// <inheritdoc />
    public partial class updateprescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Examines_Prescriptions_PrescriptionId",
                table: "Examines");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_ServiceCatalogs_ServiceGroups_ServiceGroupId",
            //    table: "ServiceCatalogs");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_ServiceCatalogs_ServiceGroups_ServiceGroupId1",
            //    table: "ServiceCatalogs");

            migrationBuilder.DropIndex(
                name: "IX_ServiceCatalogs_ServiceGroupId",
                table: "ServiceCatalogs");

            migrationBuilder.DropIndex(
                name: "IX_ServiceCatalogs_ServiceGroupId1",
                table: "ServiceCatalogs");

            //migrationBuilder.DropIndex(
            //    name: "IX_Receptions_PatientId",
            //    table: "Receptions");

            migrationBuilder.DropIndex(
                name: "IX_LabResults_ReceptionId",
                table: "LabResults");

            migrationBuilder.DropIndex(
                name: "IX_Examines_PrescriptionId",
                table: "Examines");

            migrationBuilder.DropIndex(
                name: "IX_Examines_ReceptionId",
                table: "Examines");

            migrationBuilder.DropColumn(
                name: "ServiceGroupId1",
                table: "ServiceCatalogs");

            migrationBuilder.DropColumn(
                name: "MedicalExaminationId",
                table: "Prescriptions");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ChatMessages",
                newName: "ChatMessageId");

            //migrationBuilder.AlterColumn<int>(
            //    name: "ServiceCatalogId",
            //    table: "ServiceCatalogs",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ExamineId",
                table: "Prescriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PrescriptionId1",
                table: "Examines",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TemplatePrescriptionDetails",
                columns: table => new
                {
                    PrescriptionDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplatePrescriptionId = table.Column<int>(type: "int", nullable: false),
                    DrugCatalogId = table.Column<int>(type: "int", nullable: false),
                    MorningDose = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NoonDose = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AfternoonDose = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EveningDose = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DaysOfSupply = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TemplatePrescriptionId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplatePrescriptionDetails", x => x.PrescriptionDetailId);
                    table.ForeignKey(
                        name: "FK_TemplatePrescriptionDetails_DrugCatalogs_DrugCatalogId",
                        column: x => x.DrugCatalogId,
                        principalTable: "DrugCatalogs",
                        principalColumn: "DrugCatalogId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TemplatePrescriptionDetails_Prescriptions_TemplatePrescriptionId",
                        column: x => x.TemplatePrescriptionId,
                        principalTable: "Prescriptions",
                        principalColumn: "PrescriptionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TemplatePrescriptionDetails_TemplatePrescriptions_TemplatePrescriptionId1",
                        column: x => x.TemplatePrescriptionId1,
                        principalTable: "TemplatePrescriptions",
                        principalColumn: "TemplatePrescriptionId");
                });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Receptions_PatientId",
            //    table: "Receptions",
            //    column: "PatientId",
            //    unique: true,
            //    filter: "[PatientId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LabResults_ReceptionId",
                table: "LabResults",
                column: "ReceptionId",
                unique: true,
                filter: "[ReceptionId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Examines_PrescriptionId1",
                table: "Examines",
                column: "PrescriptionId1");

            migrationBuilder.CreateIndex(
                name: "IX_Examines_ReceptionId",
                table: "Examines",
                column: "ReceptionId",
                unique: true,
                filter: "[ReceptionId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TemplatePrescriptionDetails_DrugCatalogId",
                table: "TemplatePrescriptionDetails",
                column: "DrugCatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplatePrescriptionDetails_TemplatePrescriptionId",
                table: "TemplatePrescriptionDetails",
                column: "TemplatePrescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplatePrescriptionDetails_TemplatePrescriptionId1",
                table: "TemplatePrescriptionDetails",
                column: "TemplatePrescriptionId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Examines_Prescriptions_PrescriptionId1",
                table: "Examines",
                column: "PrescriptionId1",
                principalTable: "Prescriptions",
                principalColumn: "PrescriptionId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ServiceCatalogs_ServiceGroups_ServiceCatalogId",
            //    table: "ServiceCatalogs",
            //    column: "ServiceCatalogId",
            //    principalTable: "ServiceGroups",
            //    principalColumn: "ServiceGroupId",
            //    onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Examines_Prescriptions_PrescriptionId1",
                table: "Examines");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_ServiceCatalogs_ServiceGroups_ServiceCatalogId",
            //    table: "ServiceCatalogs");

            migrationBuilder.DropTable(
                name: "TemplatePrescriptionDetails");

            //migrationBuilder.DropIndex(
            //    name: "IX_Receptions_PatientId",
            //    table: "Receptions");

            migrationBuilder.DropIndex(
                name: "IX_LabResults_ReceptionId",
                table: "LabResults");

            migrationBuilder.DropIndex(
                name: "IX_Examines_PrescriptionId1",
                table: "Examines");

            migrationBuilder.DropIndex(
                name: "IX_Examines_ReceptionId",
                table: "Examines");

            migrationBuilder.DropColumn(
                name: "ExamineId",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "PrescriptionId1",
                table: "Examines");

            migrationBuilder.RenameColumn(
                name: "ChatMessageId",
                table: "ChatMessages",
                newName: "Id");

            //migrationBuilder.AlterColumn<int>(
            //    name: "ServiceCatalogId",
            //    table: "ServiceCatalogs",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ServiceGroupId1",
                table: "ServiceCatalogs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MedicalExaminationId",
                table: "Prescriptions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCatalogs_ServiceGroupId",
                table: "ServiceCatalogs",
                column: "ServiceGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCatalogs_ServiceGroupId1",
                table: "ServiceCatalogs",
                column: "ServiceGroupId1");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Receptions_PatientId",
            //    table: "Receptions",
            //    column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_LabResults_ReceptionId",
                table: "LabResults",
                column: "ReceptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Examines_PrescriptionId",
                table: "Examines",
                column: "PrescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Examines_ReceptionId",
                table: "Examines",
                column: "ReceptionId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Examines_Prescriptions_PrescriptionId",
            //    table: "Examines",
            //    column: "PrescriptionId",
            //    principalTable: "Prescriptions",
            //    principalColumn: "PrescriptionId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ServiceCatalogs_ServiceGroups_ServiceGroupId",
            //    table: "ServiceCatalogs",
            //    column: "ServiceGroupId",
            //    principalTable: "ServiceGroups",
            //    principalColumn: "ServiceGroupId",
            //    onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ServiceCatalogs_ServiceGroups_ServiceGroupId1",
            //    table: "ServiceCatalogs",
            //    column: "ServiceGroupId1",
            //    principalTable: "ServiceGroups",
            //    principalColumn: "ServiceGroupId");
        }
    }
}

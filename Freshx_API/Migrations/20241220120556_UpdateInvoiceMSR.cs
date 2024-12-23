using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Freshx_API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInvoiceMSR : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "MedicalServiceRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "Invoices",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalServiceRequests_InvoiceId",
                table: "MedicalServiceRequests",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalServiceRequests_Invoices_InvoiceId",
                table: "MedicalServiceRequests",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "InvoiceId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalServiceRequests_Invoices_InvoiceId",
                table: "MedicalServiceRequests");

            migrationBuilder.DropIndex(
                name: "IX_MedicalServiceRequests_InvoiceId",
                table: "MedicalServiceRequests");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "MedicalServiceRequests");

            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "Invoices");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Freshx_API.Migrations
{
    /// <inheritdoc />
    public partial class ServiceCatalogDeleteDataFieldPriceType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceCatalogs_PriceTypes_PriceTypeId",
                table: "ServiceCatalogs");

            migrationBuilder.DropIndex(
                name: "IX_ServiceCatalogs_PriceTypeId",
                table: "ServiceCatalogs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ServiceCatalogs_PriceTypeId",
                table: "ServiceCatalogs",
                column: "PriceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceCatalogs_PriceTypes_PriceTypeId",
                table: "ServiceCatalogs",
                column: "PriceTypeId",
                principalTable: "PriceTypes",
                principalColumn: "PriceTypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

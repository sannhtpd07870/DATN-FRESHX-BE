using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Freshx_API.Migrations
{
    /// <inheritdoc />
    public partial class ServiceGroupUpdateDataField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "ServiceGroups",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "ServiceGroups",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServiceGroupId1",
                table: "ServiceCatalogs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCatalogs_ServiceGroupId1",
                table: "ServiceCatalogs",
                column: "ServiceGroupId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceCatalogs_ServiceGroups_ServiceGroupId1",
                table: "ServiceCatalogs",
                column: "ServiceGroupId1",
                principalTable: "ServiceGroups",
                principalColumn: "ServiceGroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceCatalogs_ServiceGroups_ServiceGroupId1",
                table: "ServiceCatalogs");

            migrationBuilder.DropIndex(
                name: "IX_ServiceCatalogs_ServiceGroupId1",
                table: "ServiceCatalogs");

            migrationBuilder.DropColumn(
                name: "ServiceGroupId1",
                table: "ServiceCatalogs");

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "ServiceGroups",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "ServiceGroups",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}

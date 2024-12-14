using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Freshx_API.Migrations
{
    /// <inheritdoc />
    public partial class DiaChi2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_District_Province_ProvinceCode",
                table: "District");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_District_DistrictCode",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Province_ProvinceCode",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Ward_WardCode",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_District_DistrictCode",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Province_ProvinceCode",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Ward_WardCode",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Ward_District_DistrictCode",
                table: "Ward");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ward",
                table: "Ward");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Province",
                table: "Province");

            migrationBuilder.DropPrimaryKey(
                name: "PK_District",
                table: "District");

            migrationBuilder.RenameTable(
                name: "Ward",
                newName: "Wards");

            migrationBuilder.RenameTable(
                name: "Province",
                newName: "Provinces");

            migrationBuilder.RenameTable(
                name: "District",
                newName: "Districts");

            migrationBuilder.RenameIndex(
                name: "IX_Ward_DistrictCode",
                table: "Wards",
                newName: "IX_Wards_DistrictCode");

            migrationBuilder.RenameIndex(
                name: "IX_District_ProvinceCode",
                table: "Districts",
                newName: "IX_Districts_ProvinceCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wards",
                table: "Wards",
                column: "Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Provinces",
                table: "Provinces",
                column: "Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Districts",
                table: "Districts",
                column: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_Districts_Provinces_ProvinceCode",
                table: "Districts",
                column: "ProvinceCode",
                principalTable: "Provinces",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Districts_DistrictCode",
                table: "Employees",
                column: "DistrictCode",
                principalTable: "Districts",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Provinces_ProvinceCode",
                table: "Employees",
                column: "ProvinceCode",
                principalTable: "Provinces",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Wards_WardCode",
                table: "Employees",
                column: "WardCode",
                principalTable: "Wards",
                principalColumn: "Code");

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
                name: "FK_Patients_Wards_WardCode",
                table: "Patients",
                column: "WardCode",
                principalTable: "Wards",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_Wards_Districts_DistrictCode",
                table: "Wards",
                column: "DistrictCode",
                principalTable: "Districts",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Districts_Provinces_ProvinceCode",
                table: "Districts");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Districts_DistrictCode",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Provinces_ProvinceCode",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Wards_WardCode",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Districts_DistrictCode",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Provinces_ProvinceCode",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Wards_WardCode",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Wards_Districts_DistrictCode",
                table: "Wards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wards",
                table: "Wards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Provinces",
                table: "Provinces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Districts",
                table: "Districts");

            migrationBuilder.RenameTable(
                name: "Wards",
                newName: "Ward");

            migrationBuilder.RenameTable(
                name: "Provinces",
                newName: "Province");

            migrationBuilder.RenameTable(
                name: "Districts",
                newName: "District");

            migrationBuilder.RenameIndex(
                name: "IX_Wards_DistrictCode",
                table: "Ward",
                newName: "IX_Ward_DistrictCode");

            migrationBuilder.RenameIndex(
                name: "IX_Districts_ProvinceCode",
                table: "District",
                newName: "IX_District_ProvinceCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ward",
                table: "Ward",
                column: "Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Province",
                table: "Province",
                column: "Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_District",
                table: "District",
                column: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_District_Province_ProvinceCode",
                table: "District",
                column: "ProvinceCode",
                principalTable: "Province",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_District_DistrictCode",
                table: "Employees",
                column: "DistrictCode",
                principalTable: "District",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Province_ProvinceCode",
                table: "Employees",
                column: "ProvinceCode",
                principalTable: "Province",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Ward_WardCode",
                table: "Employees",
                column: "WardCode",
                principalTable: "Ward",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_District_DistrictCode",
                table: "Patients",
                column: "DistrictCode",
                principalTable: "District",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Province_ProvinceCode",
                table: "Patients",
                column: "ProvinceCode",
                principalTable: "Province",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Ward_WardCode",
                table: "Patients",
                column: "WardCode",
                principalTable: "Ward",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_Ward_District_DistrictCode",
                table: "Ward",
                column: "DistrictCode",
                principalTable: "District",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Freshx_API.Migrations
{
    /// <inheritdoc />
    public partial class DiaChi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_AdministrativeUnits_DistrictId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_AdministrativeUnits_ProvinceId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_AdministrativeUnits_WardId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_AdministrativeUnits_DistrictId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_AdministrativeUnits_ProvinceId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_AdministrativeUnits_WardId",
                table: "Patients");

            migrationBuilder.DropTable(
                name: "AdministrativeUnits");

            migrationBuilder.DropIndex(
                name: "IX_Patients_DistrictId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_ProvinceId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_WardId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DistrictId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ProvinceId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_WardId",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "DistrictCode",
                table: "Patients",
                type: "nvarchar(20)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProvinceCode",
                table: "Patients",
                type: "nvarchar(20)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WardCode",
                table: "Patients",
                type: "nvarchar(20)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DistrictCode",
                table: "Employees",
                type: "nvarchar(20)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProvinceCode",
                table: "Employees",
                type: "nvarchar(20)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WardCode",
                table: "Employees",
                type: "nvarchar(20)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Province",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FullNameEn = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CodeName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AdministrativeUnitId = table.Column<int>(type: "int", nullable: true),
                    AdministrativeRegionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Province", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "District",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FullNameEn = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CodeName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    ProvinceCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AdministrativeUnitId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_District", x => x.Code);
                    table.ForeignKey(
                        name: "FK_District_Province_ProvinceCode",
                        column: x => x.ProvinceCode,
                        principalTable: "Province",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ward",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FullNameEn = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CodeName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DistrictCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AdministrativeUnitId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ward", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Ward_District_DistrictCode",
                        column: x => x.DistrictCode,
                        principalTable: "District",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_DistrictCode",
                table: "Patients",
                column: "DistrictCode");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_ProvinceCode",
                table: "Patients",
                column: "ProvinceCode");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_WardCode",
                table: "Patients",
                column: "WardCode");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DistrictCode",
                table: "Employees",
                column: "DistrictCode");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ProvinceCode",
                table: "Employees",
                column: "ProvinceCode");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_WardCode",
                table: "Employees",
                column: "WardCode");

            migrationBuilder.CreateIndex(
                name: "IX_District_ProvinceCode",
                table: "District",
                column: "ProvinceCode");

            migrationBuilder.CreateIndex(
                name: "IX_Ward_DistrictCode",
                table: "Ward",
                column: "DistrictCode");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropTable(
                name: "Ward");

            migrationBuilder.DropTable(
                name: "District");

            migrationBuilder.DropTable(
                name: "Province");

            migrationBuilder.DropIndex(
                name: "IX_Patients_DistrictCode",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_ProvinceCode",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_WardCode",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DistrictCode",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ProvinceCode",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_WardCode",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DistrictCode",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "ProvinceCode",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "WardCode",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "DistrictCode",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ProvinceCode",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "WardCode",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "AdministrativeUnits");
              
        }
    }
}

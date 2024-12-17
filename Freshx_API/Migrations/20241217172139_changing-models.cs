using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Freshx_API.Migrations
{
    /// <inheritdoc />
    public partial class changingmodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Districts_DistrictCode",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Provinces_ProvinceCode",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Wards_WardCode",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_DistrictCode",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_ProvinceCode",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_WardCode",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "ContactAddress",
                table: "Receptions");

            migrationBuilder.DropColumn(
                name: "ReceptionMonth",
                table: "Receptions");

            migrationBuilder.DropColumn(
                name: "ReceptionTime",
                table: "Receptions");

            migrationBuilder.DropColumn(
                name: "ReceptionYear",
                table: "Receptions");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "DistrictCode",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "ProvinceCode",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "TaxCode",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "WardCode",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "WardId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "ZaloId",
                table: "Patients");

            migrationBuilder.AlterColumn<string>(
                name: "Ethnicity",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Receptionist",
                columns: table => new
                {
                    ReceptionistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsSuspended = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receptionist", x => x.ReceptionistId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Receptions_ReceptionistId",
                table: "Receptions",
                column: "ReceptionistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receptions_Receptionist_ReceptionistId",
                table: "Receptions",
                column: "ReceptionistId",
                principalTable: "Receptionist",
                principalColumn: "ReceptionistId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receptions_Receptionist_ReceptionistId",
                table: "Receptions");

            migrationBuilder.DropTable(
                name: "Receptionist");

            migrationBuilder.DropIndex(
                name: "IX_Receptions_ReceptionistId",
                table: "Receptions");

            migrationBuilder.AddColumn<string>(
                name: "ContactAddress",
                table: "Receptions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReceptionMonth",
                table: "Receptions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReceptionTime",
                table: "Receptions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReceptionYear",
                table: "Receptions",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Ethnicity",
                table: "Patients",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

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
                name: "TaxCode",
                table: "Patients",
                type: "nvarchar(max)",
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
                name: "ZaloId",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

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
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Freshx_API.Migrations
{
    /// <inheritdoc />
    public partial class changing_PatientModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receptions_Receptionist_ReceptionistId",
                table: "Receptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Receptionist",
                table: "Receptionist");

            migrationBuilder.DropColumn(
                name: "YearOfBirth",
                table: "Patients");

            migrationBuilder.RenameTable(
                name: "Receptionist",
                newName: "Receptionists");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Patients",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Receptionists",
                table: "Receptionists",
                column: "ReceptionistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receptions_Receptionists_ReceptionistId",
                table: "Receptions",
                column: "ReceptionistId",
                principalTable: "Receptionists",
                principalColumn: "ReceptionistId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receptions_Receptionists_ReceptionistId",
                table: "Receptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Receptionists",
                table: "Receptionists");

            migrationBuilder.RenameTable(
                name: "Receptionists",
                newName: "Receptionist");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Patients",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YearOfBirth",
                table: "Patients",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Receptionist",
                table: "Receptionist",
                column: "ReceptionistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receptions_Receptionist_ReceptionistId",
                table: "Receptions",
                column: "ReceptionistId",
                principalTable: "Receptionist",
                principalColumn: "ReceptionistId");
        }
    }
}

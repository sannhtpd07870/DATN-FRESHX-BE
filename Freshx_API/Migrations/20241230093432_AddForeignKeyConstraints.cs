using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Freshx_API.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_AspNetUsers_AccountId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_AspNetUsers_AccountId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_AspNetUsers_AccountId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Technicians_AspNetUsers_AccountId",
                table: "Technicians");

            migrationBuilder.AlterColumn<decimal>(
                name: "ConversionValue",
                table: "UnitOfMeasures",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_AspNetUsers_AccountId",
                table: "Doctors",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_AspNetUsers_AccountId",
                table: "Employees",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_AspNetUsers_AccountId",
                table: "Patients",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Technicians_AspNetUsers_AccountId",
                table: "Technicians",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_AspNetUsers_AccountId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_AspNetUsers_AccountId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_AspNetUsers_AccountId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Technicians_AspNetUsers_AccountId",
                table: "Technicians");

            migrationBuilder.AlterColumn<decimal>(
                name: "ConversionValue",
                table: "UnitOfMeasures",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_AspNetUsers_AccountId",
                table: "Doctors",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_AspNetUsers_AccountId",
                table: "Employees",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_AspNetUsers_AccountId",
                table: "Patients",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Technicians_AspNetUsers_AccountId",
                table: "Technicians",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Freshx_API.Migrations
{
    /// <inheritdoc />
    public partial class upgradereception17 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ServiceTotalAmount",
                table: "Receptions",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ServiceTotalAmount",
                table: "Receptions",
                type: "int",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);
        }
    }
}

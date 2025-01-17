using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Freshx_API.Migrations
{
    /// <inheritdoc />
    public partial class upgradeservice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            // Thêm các cột mới
            migrationBuilder.AddColumn<int>(
                name: "UnitOfMeasureId",
                table: "ServiceCatalogs",
                nullable: true);

            migrationBuilder.DropColumn(
           name: "UnitOfMeasure",
           table: "ServiceCatalogs");
        
        migrationBuilder.AlterColumn<bool>(
                name: "ServiceStandardValueId",
                table: "ServiceCatalogs",
                nullable: true);

            // Sửa đổi kiểu dữ liệu hoặc cấu hình các cột nếu cần
            migrationBuilder.AlterColumn<int>(
                name: "IsSuspended",
                table: "ServiceCatalogs",
                nullable: false,
                defaultValue: 0); // Đảm bảo trạng thái mặc định

            // Thêm các khóa ngoại mới
            migrationBuilder.AddForeignKey(
                name: "FK_ServiceCatalogs_UnitOfMeasures_UnitOfMeasureId",
                table: "ServiceCatalogs",
                column: "UnitOfMeasureId",
                principalTable: "UnitOfMeasures",
                principalColumn: "UnitOfMeasureId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
             // Xóa các thay đổi nếu cần rollback
        migrationBuilder.DropForeignKey(
            name: "FK_ServiceCatalogs_UnitOfMeasures_UnitOfMeasureId",
            table: "ServiceCatalogs");


        migrationBuilder.DropColumn(
            name: "UnitOfMeasureId",
            table: "ServiceCatalogs");

        migrationBuilder.DropColumn(
            name: "ServiceStandardValueId",
            table: "ServiceCatalogs");

        migrationBuilder.AlterColumn<int>(
            name: "IsSuspended",
            table: "ServiceCatalogs",
            nullable: false,
            oldClrType: typeof(int),
            oldDefaultValue: 0);
        }
    }
}

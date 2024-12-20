using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Freshx_API.Migrations
{
    /// <inheritdoc />
    public partial class updatingModelAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AvatarId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DistrictCode",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DistrictId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentityCardNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProvinceCode",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProvinceId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WardCode",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WardId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DistrictCode",
                table: "AspNetUsers",
                column: "DistrictCode");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PositionId",
                table: "AspNetUsers",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ProvinceCode",
                table: "AspNetUsers",
                column: "ProvinceCode");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_WardCode",
                table: "AspNetUsers",
                column: "WardCode");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Districts_DistrictCode",
                table: "AspNetUsers",
                column: "DistrictCode",
                principalTable: "Districts",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Position_PositionId",
                table: "AspNetUsers",
                column: "PositionId",
                principalTable: "Position",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Provinces_ProvinceCode",
                table: "AspNetUsers",
                column: "ProvinceCode",
                principalTable: "Provinces",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Wards_WardCode",
                table: "AspNetUsers",
                column: "WardCode",
                principalTable: "Wards",
                principalColumn: "Code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Districts_DistrictCode",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Position_PositionId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Provinces_ProvinceCode",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Wards_WardCode",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DistrictCode",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PositionId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ProvinceCode",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_WardCode",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AvatarId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DistrictCode",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IdentityCardNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProvinceCode",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WardCode",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WardId",
                table: "AspNetUsers");
        }
    }
}

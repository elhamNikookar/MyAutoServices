using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyAutoService.Migrations
{
    public partial class final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_AspNetUsers_UserID",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceDetails_ServiceHeaders_ServiceHeader",
                table: "ServiceDetails");

            migrationBuilder.AlterColumn<string>(
                name: "ServiceName",
                table: "ServiceDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceHeader",
                table: "ServiceDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Cars",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_AspNetUsers_UserID",
                table: "Cars",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceDetails_ServiceHeaders_ServiceHeader",
                table: "ServiceDetails",
                column: "ServiceHeader",
                principalTable: "ServiceHeaders",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_AspNetUsers_UserID",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceDetails_ServiceHeaders_ServiceHeader",
                table: "ServiceDetails");

            migrationBuilder.AlterColumn<string>(
                name: "ServiceName",
                table: "ServiceDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ServiceHeader",
                table: "ServiceDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Cars",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_AspNetUsers_UserID",
                table: "Cars",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceDetails_ServiceHeaders_ServiceHeader",
                table: "ServiceDetails",
                column: "ServiceHeader",
                principalTable: "ServiceHeaders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

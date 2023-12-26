using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyAutoService.Migrations
{
    public partial class AddTableShoppingCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceHeaders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Miles = table.Column<double>(type: "float", nullable: true),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CarID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceHeaders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ServiceHeaders_Cars_CarID",
                        column: x => x.CarID,
                        principalTable: "Cars",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServicesShoppingCarts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarID = table.Column<int>(type: "int", nullable: false),
                    ServiceTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicesShoppingCarts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ServicesShoppingCarts_Cars_CarID",
                        column: x => x.CarID,
                        principalTable: "Cars",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServicesShoppingCarts_ServiceTypes_ServiceTypeID",
                        column: x => x.ServiceTypeID,
                        principalTable: "ServiceTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceHeaderID = table.Column<int>(type: "int", nullable: false),
                    ServiceHeader = table.Column<int>(type: "int", nullable: false),
                    ServiceTypeID = table.Column<int>(type: "int", nullable: false),
                    ServicePrice = table.Column<double>(type: "float", nullable: false),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ServiceDetails_ServiceHeaders_ServiceHeader",
                        column: x => x.ServiceHeader,
                        principalTable: "ServiceHeaders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceDetails_ServiceTypes_ServiceTypeID",
                        column: x => x.ServiceTypeID,
                        principalTable: "ServiceTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceDetails_ServiceHeader",
                table: "ServiceDetails",
                column: "ServiceHeader");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceDetails_ServiceTypeID",
                table: "ServiceDetails",
                column: "ServiceTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceHeaders_CarID",
                table: "ServiceHeaders",
                column: "CarID");

            migrationBuilder.CreateIndex(
                name: "IX_ServicesShoppingCarts_CarID",
                table: "ServicesShoppingCarts",
                column: "CarID");

            migrationBuilder.CreateIndex(
                name: "IX_ServicesShoppingCarts_ServiceTypeID",
                table: "ServicesShoppingCarts",
                column: "ServiceTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceDetails");

            migrationBuilder.DropTable(
                name: "ServicesShoppingCarts");

            migrationBuilder.DropTable(
                name: "ServiceHeaders");
        }
    }
}

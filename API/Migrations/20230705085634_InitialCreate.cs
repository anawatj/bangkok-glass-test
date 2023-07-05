using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RegionName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegionId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CityId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { "262474b5-eba8-4f88-bcd8-a3c70aaf74d8", "Bars" },
                    { "8959b817-2c19-47ac-ae3f-4f446638619e", "Crackers" },
                    { "db9c8841-efbd-48e3-9636-11c7de440010", "Cookies" },
                    { "e21d6266-ff57-4ee0-9b7f-26492e8878c4", "Snack" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "RegionName" },
                values: new object[,]
                {
                    { "43380845-8317-409b-803c-c73e47bf875a", "WEST" },
                    { "fb75e403-e2d9-4fa8-a499-46995aea008d", "EAST" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CityName", "RegionId" },
                values: new object[,]
                {
                    { "ba0c074a-8388-4ca1-8918-1bb29c47201c", "New York", "fb75e403-e2d9-4fa8-a499-46995aea008d" },
                    { "ba999d0d-3f3f-4c84-9245-61fb1a98c852", "Los Angeles", "43380845-8317-409b-803c-c73e47bf875a" },
                    { "f66d70c2-fb76-47cd-b857-8a1f95cc6f26", "Boston", "fb75e403-e2d9-4fa8-a499-46995aea008d" },
                    { "f71e8d8b-55fe-444a-99b8-945704c0d650", "Santiago", "43380845-8317-409b-803c-c73e47bf875a" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "ProductName" },
                values: new object[,]
                {
                    { "2d0ded5e-2356-4b51-944c-da716ae1c657", "db9c8841-efbd-48e3-9636-11c7de440010", "Arrowroot" },
                    { "388f2e8e-ab0d-4f32-91ce-78b13de46758", "db9c8841-efbd-48e3-9636-11c7de440010", "Chocolate Chip" },
                    { "5e5a1cc6-e795-47da-aae6-3b9124b6ef3e", "e21d6266-ff57-4ee0-9b7f-26492e8878c4", "Potato Chips" },
                    { "a46fd69c-9b80-41e1-a203-b5e5e0279e87", "262474b5-eba8-4f88-bcd8-a3c70aaf74d8", "Bran" },
                    { "b84efd99-bf35-4a33-9653-8aebd7ccbb39", "e21d6266-ff57-4ee0-9b7f-26492e8878c4", "Pretzels" },
                    { "b921c3de-f523-4d9b-85c1-1ec754506cc6", "8959b817-2c19-47ac-ae3f-4f446638619e", "Whole Wheat" },
                    { "dbd3518a-2a27-44d8-8fb2-09ebadacaaaf", "262474b5-eba8-4f88-bcd8-a3c70aaf74d8", "Carrot" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_RegionId",
                table: "Cities",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CategoryId",
                table: "Orders",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CityId",
                table: "Orders",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductId",
                table: "Orders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_RegionId",
                table: "Orders",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}

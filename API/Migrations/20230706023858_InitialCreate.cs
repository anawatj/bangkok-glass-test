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
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false)
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
                    { "97b33437-52a3-46f1-867c-c310d3ef73e8", "Cookies" },
                    { "a53e48a5-e145-46fe-a59b-00811fb4307b", "Crackers" },
                    { "e0273c5f-5aa2-4fb7-a251-3190a01443c7", "Snack" },
                    { "f4f4de08-f4b2-4ec6-9471-0af49fbf197b", "Bars" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "RegionName" },
                values: new object[,]
                {
                    { "5a09f202-9faf-412a-98e3-44e85188cf77", "WEST" },
                    { "baa1f397-c98c-4c96-b69b-953833a6f844", "EAST" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CityName", "RegionId" },
                values: new object[,]
                {
                    { "1e57a5de-be7e-4c25-9c11-becbd81ffc9c", "Los Angeles", "5a09f202-9faf-412a-98e3-44e85188cf77" },
                    { "59d0a0c2-f34b-4397-882d-96f1c354070f", "Santiago", "5a09f202-9faf-412a-98e3-44e85188cf77" },
                    { "6631cdd2-2e26-4128-808c-b99a7a568353", "New York", "baa1f397-c98c-4c96-b69b-953833a6f844" },
                    { "ca1563ed-a933-499c-be6e-c38f65cc66e6", "Boston", "baa1f397-c98c-4c96-b69b-953833a6f844" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "ProductName", "UnitPrice" },
                values: new object[,]
                {
                    { "2373dba0-fb7e-49ed-8e31-35a860c5d21a", "97b33437-52a3-46f1-867c-c310d3ef73e8", "Chocolate Chip", 1.87m },
                    { "645c2070-63b3-4c67-8acf-2f6e5b6156ec", "a53e48a5-e145-46fe-a59b-00811fb4307b", "Whole Wheat", 3.49m },
                    { "8a17a631-2626-466c-b0e0-c1d398bb5737", "f4f4de08-f4b2-4ec6-9471-0af49fbf197b", "Bran", 1.87m },
                    { "8c4de4d3-188f-4566-a116-0ca3f92d9be5", "e0273c5f-5aa2-4fb7-a251-3190a01443c7", "Pretzels", 3.15m },
                    { "af0b5805-0db4-4eb7-aa30-c6d97c5360b0", "97b33437-52a3-46f1-867c-c310d3ef73e8", "Arrowroot", 2.18m },
                    { "b97ae87a-1d61-4120-ae0b-e248e3b9a02a", "f4f4de08-f4b2-4ec6-9471-0af49fbf197b", "Carrot", 1.77m },
                    { "cca4be31-8b1a-4ac7-900d-fc601a1bcf62", "e0273c5f-5aa2-4fb7-a251-3190a01443c7", "Potato Chips", 1.35m }
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

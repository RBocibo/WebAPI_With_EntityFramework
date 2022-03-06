using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikeShop.Entities.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    BrandID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.BrandID);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    City = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Province = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModelYear = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "BrandID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    StoreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contacts = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.StoreId);
                    table.ForeignKey(
                        name: "FK_Store_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequiredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShippedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "BrandID", "BrandName" },
                values: new object[,]
                {
                    { 1, "Max" },
                    { 2, "RMB" },
                    { 3, "Max" },
                    { 4, "Big Max" }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Children Bike" },
                    { 2, "Road Bike" },
                    { 3, "Mountain Bike" },
                    { 4, "Electric Bike" }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "City", "ContactNumber", "Country", "Email", "FirstName", "LastName", "PostalCode", "Province", "Street" },
                values: new object[,]
                {
                    { 1, "Centurion", "012365478", "SA", "roseyboxa@gmail.com", "Rosey", "Boxa", "125", "Gauteng", "12 Cool str" },
                    { 2, "Bloemfontein", "05123654", "SA", "oozyCheal@gmail.com", "Oozy", "Cheal", "125", "Free State", "11A Kerol str" },
                    { 3, "Centurion", "012365478", "SA", "luluMini@gmail.com", "Lulu", "Mini", "1235", "Gauteng", "785 Mapel str" },
                    { 4, "Minlerton", "012365478", "SA", "roxyFerero@gmail.com", "Roxy", "Ferero", "001", "Western Cape", "85 Ocean Breeze str" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "BrandId", "CategoryId", "ModelYear", "Price", "ProductName" },
                values: new object[,]
                {
                    { 1, 1, 1, 2020, 1200m, "Bmax 4 wiler" },
                    { 2, 2, 2, 2018, 2300m, "RMB Max" },
                    { 3, 3, 3, 2007, 800m, "Bmax 4 wiler" },
                    { 4, 4, 4, 2020, 1500m, "Max" }
                });

            migrationBuilder.InsertData(
                table: "Store",
                columns: new[] { "StoreId", "Address", "Contacts", "Email", "ProductId", "StoreName" },
                values: new object[] { 1, "121 Lake street Sandton Gauteng", 123654, "bikeSonton@bikeshop.co.za", 1, "Sandton Shop" });

            migrationBuilder.InsertData(
                table: "Store",
                columns: new[] { "StoreId", "Address", "Contacts", "Email", "ProductId", "StoreName" },
                values: new object[] { 2, "10 Ocean Blue Mall  CapeTown Western Cape", 123654, "bikeCapeTown@bikeshop.co.za", 2, "Cape Town Shop" });

            migrationBuilder.InsertData(
                table: "Store",
                columns: new[] { "StoreId", "Address", "Contacts", "Email", "ProductId", "StoreName" },
                values: new object[] { 3, "Rich street 10A Bloem FS", 123654, "bikeBloem@bikeshop.co.za", 2, "Bloemfontein Shop" });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderId", "CustomerId", "OrderDate", "RequiredDate", "ShippedDate", "StoreId" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2020, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 3, new DateTime(2021, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, 4, new DateTime(2020, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, 2, new DateTime(2021, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_StoreId",
                table: "Order",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_BrandId",
                table: "Product",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Store_ProductId",
                table: "Store",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlakeHunt_WebAPI_Final.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Total = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "Costomers",
                columns: table => new
                {
                    CustId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Costomers", x => x.CustId);
                    table.ForeignKey(
                        name: "FK_Costomers_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Products_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId");
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustId = table.Column<int>(type: "int", nullable: false),
                    CustomerCustId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Address_Costomers_CustomerCustId",
                        column: x => x.CustomerCustId,
                        principalTable: "Costomers",
                        principalColumn: "CustId");
                });

            migrationBuilder.CreateTable(
                name: "Phone",
                columns: table => new
                {
                    PhoneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustId = table.Column<int>(type: "int", nullable: false),
                    CustomerCustId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phone", x => x.PhoneId);
                    table.ForeignKey(
                        name: "FK_Phone_Costomers_CustomerCustId",
                        column: x => x.CustomerCustId,
                        principalTable: "Costomers",
                        principalColumn: "CustId");
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "AddressId", "City", "Country", "CustId", "CustomerCustId", "State", "StreetAdress" },
                values: new object[,]
                {
                    { 1, "Tenino", "United States", 3, null, "idk", "322 Gwen Street" },
                    { 2, "London", "United Kingdom", 2, null, null, "556 Garb Rd" },
                    { 3, "Centralia", "United States", 3, null, "Washinton", "239 Silver Street" }
                });

            migrationBuilder.InsertData(
                table: "Costomers",
                columns: new[] { "CustId", "BirthDate", "FirstName", "LastName", "OrderId" },
                values: new object[,]
                {
                    { 1, null, "Gohn", "Zmith", null },
                    { 2, null, "Janice", "1", null },
                    { 3, null, "peith", "lowercase", null }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "Total" },
                values: new object[,]
                {
                    { 1, 500.0 },
                    { 2, 95.0 },
                    { 3, 44.450000000000003 }
                });

            migrationBuilder.InsertData(
                table: "Phone",
                columns: new[] { "PhoneId", "CustId", "CustomerCustId", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 1, null, "564-555-2535" },
                    { 2, 2, null, "020-555-2745" },
                    { 3, 3, null, "360-555-5764" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "OrderId", "Price", "ProductDescription", "ProductName" },
                values: new object[,]
                {
                    { 1, null, 10.0, "shirt", "shirt" },
                    { 2, null, 20.0, "pants", "pair of pant" },
                    { 3, null, 45.0, "for feet", "shoes" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CustomerCustId",
                table: "Address",
                column: "CustomerCustId");

            migrationBuilder.CreateIndex(
                name: "IX_Costomers_OrderId",
                table: "Costomers",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Phone_CustomerCustId",
                table: "Phone",
                column: "CustomerCustId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrderId",
                table: "Products",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Phone");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Costomers");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}

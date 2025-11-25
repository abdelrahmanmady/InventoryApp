using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Devices, gadgets, and smart technology products.", "Electronics" },
                    { 2, "Fashion apparel for men, women, and children.", "Clothing" },
                    { 3, "Household essentials, cookware, and home accessories.", "Home & Kitchen" },
                    { 4, "Sporting goods, fitness equipment, and outdoor gear.", "Sports" },
                    { 5, "Printed and digital books across various genres.", "Books" },
                    { 6, "Cosmetics, skincare, and beauty care products.", "Beauty" },
                    { 7, "Toys, games, and educational products for kids.", "Toys" },
                    { 8, "Car accessories, maintenance supplies, and tools.", "Automotive" },
                    { 9, "Everyday food items, beverages, and household necessities.", "Groceries" },
                    { 10, "Fashion accessories including bags, belts, and jewelry.", "Accessories" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Latest-gen smartphone with high-end features.", null, "Smartphone X", 899.99m },
                    { 2, 1, "Noise-cancelling over-ear headphones.", null, "Wireless Headphones", 199.50m },
                    { 3, 2, "100% cotton casual t-shirt.", null, "Men's T-Shirt", 29.99m },
                    { 4, 3, "Durable non-stick cookware for everyday use.", null, "Non-Stick Frying Pan", 45.00m },
                    { 5, 4, "Anti-slip fitness mat for workouts.", null, "Yoga Mat", 25.75m },
                    { 6, 5, "Bestselling adventure fantasy book.", null, "Fantasy Novel", 15.99m },
                    { 7, 6, "Hydrating skincare cream for daily use.", null, "Face Moisturizer", 12.49m },
                    { 8, 7, "Colorful puzzle set for early learning.", null, "Kids Puzzle Set", 18.00m },
                    { 9, 8, "Dashboard mount for smartphones.", null, "Car Phone Mount", 9.99m },
                    { 10, 9, "Extra virgin olive oil for cooking.", null, "Organic Olive Oil", 7.99m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}

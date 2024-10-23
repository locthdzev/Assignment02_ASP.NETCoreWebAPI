using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    author_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    zip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email_address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.author_id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    pub_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    publisher_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.pub_id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role_desc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    book_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pub_id = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    advance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    royalty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ytd_sales = table.Column<int>(type: "int", nullable: false),
                    notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    published_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.book_id);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_pub_id",
                        column: x => x.pub_id,
                        principalTable: "Publishers",
                        principalColumn: "pub_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email_address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    middle_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    role_id = table.Column<int>(type: "int", nullable: false),
                    pub_id = table.Column<int>(type: "int", nullable: false),
                    hire_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_Users_Publishers_pub_id",
                        column: x => x.pub_id,
                        principalTable: "Publishers",
                        principalColumn: "pub_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Roles_role_id",
                        column: x => x.role_id,
                        principalTable: "Roles",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookAuthors",
                columns: table => new
                {
                    author_id = table.Column<int>(type: "int", nullable: false),
                    book_id = table.Column<int>(type: "int", nullable: false),
                    author_order = table.Column<int>(type: "int", nullable: false),
                    royality_percentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthors", x => new { x.book_id, x.author_id });
                    table.ForeignKey(
                        name: "FK_BookAuthors_Authors_author_id",
                        column: x => x.author_id,
                        principalTable: "Authors",
                        principalColumn: "author_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAuthors_Books_book_id",
                        column: x => x.book_id,
                        principalTable: "Books",
                        principalColumn: "book_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "author_id", "address", "city", "email_address", "first_name", "last_name", "phone", "state", "zip" },
                values: new object[,]
                {
                    { 1, "123 Main St", "New York", "john.doe@example.com", "John", "Doe", "123-456-7890", "NY", "10001" },
                    { 2, "456 Maple Ave", "Los Angeles", "jane.smith@example.com", "Jane", "Smith", "098-765-4321", "CA", "90001" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "pub_id", "city", "country", "publisher_name", "state" },
                values: new object[,]
                {
                    { 1, "Sebastopol", "USA", "O'Reilly Media", "CA" },
                    { 2, "Birmingham", "UK", "Packt Publishing", "West Midlands" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "role_id", "role_desc" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "book_id", "advance", "notes", "price", "pub_id", "published_date", "royalty", "title", "type", "ytd_sales" },
                values: new object[,]
                {
                    { 1, 5000m, "Excellent resource", 49.99m, 1, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10m, "Learning EF Core", "Technical", 500 },
                    { 2, 6000m, "Highly recommended", 59.99m, 2, new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 12m, "Mastering ASP.NET", "Technical", 300 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "user_id", "email_address", "first_name", "hire_date", "last_name", "middle_name", "password", "pub_id", "role_id", "source" },
                values: new object[,]
                {
                    { 1, "admin@example.com", "Admin", new DateTime(2024, 10, 21, 14, 52, 48, 485, DateTimeKind.Local).AddTicks(614), "User", "", "password", 1, 1, "Internal" },
                    { 2, "user@example.com", "Normal", new DateTime(2024, 10, 21, 14, 52, 48, 485, DateTimeKind.Local).AddTicks(629), "User", "", "password", 2, 2, "Internal" }
                });

            migrationBuilder.InsertData(
                table: "BookAuthors",
                columns: new[] { "author_id", "book_id", "author_order", "royality_percentage" },
                values: new object[,]
                {
                    { 1, 1, 1, 10m },
                    { 2, 2, 1, 12m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_author_id",
                table: "BookAuthors",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "IX_Books_pub_id",
                table: "Books",
                column: "pub_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_pub_id",
                table: "Users",
                column: "pub_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_role_id",
                table: "Users",
                column: "role_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAuthors");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}

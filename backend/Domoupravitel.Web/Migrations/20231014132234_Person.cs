using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domoupravitel.Web.Migrations
{
    /// <inheritdoc />
    public partial class Person : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3c871b20-cfd8-4d65-af67-e873ac28107c");

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e3261f54-0bb8-43df-809d-4eb05f7b2296", 0, "032e82a0-2659-45b5-a45d-5e5fb84b5144", null, false, false, null, "wnvko", null, null, "AQAAAAEAACcQAAAAEMFLlOY9/oG9R5mT/BcE0rvq1ZR5pHMMjhEmZnt2f6+IGoTQo4+BrKL1069/IhlM3w==", null, false, "a2101dd1-f3e7-44e1-b325-57bc33641c02", false, "wnvko" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "e3261f54-0bb8-43df-809d-4eb05f7b2296");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3c871b20-cfd8-4d65-af67-e873ac28107c", 0, "8ad2e3f5-e3f4-4377-994d-41861cf6aadc", null, false, false, null, "wnvko", null, null, "AQAAAAEAACcQAAAAEP282jYVNh7fxE1ZRAcM9wGnJ4ykjPv0nAkQkxgsK8x/GJzUJMqYBfsifv7M7lApzA==", null, false, "78bb4bdb-0867-4690-bb45-fe1aad3f0537", false, "wnvko" });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class Pets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "ed7862bf-8854-410b-bab4-7619a28a447e");

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Number = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5bff0612-b55a-4416-9739-40603442980d", 0, "0f074e9e-9afc-411a-a9b2-770d0b2543c9", null, false, false, null, "wnvko", null, null, "AQAAAAEAACcQAAAAENwCNCTHf0WdMVd51f0Wq7kWt9E8l3RF0SpQWSFZVSJAGGtWDgta6DQNw4K93265UQ==", null, false, 0, "9e355361-fd11-4716-aba3-965a9d200781", false, "wnvko" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "5bff0612-b55a-4416-9739-40603442980d");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ed7862bf-8854-410b-bab4-7619a28a447e", 0, "e9658107-32b4-4cd3-b0a0-1769c45cef53", null, false, false, null, "wnvko", null, null, "AQAAAAEAACcQAAAAEO7wu2gM4XKC6+PP86Pj5j2hBb/eT+AUbHxzQuytr4hs1Y9TbDYZvfOfsSHedVqOkQ==", null, false, 0, "acb78589-6779-4f7c-a189-3f8436bbe484", false, "wnvko" });
        }
    }
}

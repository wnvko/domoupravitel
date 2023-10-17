using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class Cars : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1725d11c-f721-4ad5-a97a-593237e26f6e");

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Number = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Brand = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Color = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ed7862bf-8854-410b-bab4-7619a28a447e", 0, "e9658107-32b4-4cd3-b0a0-1769c45cef53", null, false, false, null, "wnvko", null, null, "AQAAAAEAACcQAAAAEO7wu2gM4XKC6+PP86Pj5j2hBb/eT+AUbHxzQuytr4hs1Y9TbDYZvfOfsSHedVqOkQ==", null, false, 0, "acb78589-6779-4f7c-a189-3f8436bbe484", false, "wnvko" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "ed7862bf-8854-410b-bab4-7619a28a447e");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1725d11c-f721-4ad5-a97a-593237e26f6e", 0, "35a14008-a2d5-4480-b37f-561342b423eb", null, false, false, null, "wnvko", null, null, "AQAAAAEAACcQAAAAEHi2FfXhTNNFnnevOrrcvawiUavgqmO8w01saZX5vlZT6qQxr6NRRtfBQMYWohEs1Q==", null, false, 0, "0d7840cc-1ce6-4e11-a369-6ede71cdd1f2", false, "wnvko" });
        }
    }
}

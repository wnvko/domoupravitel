using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domoupravitel.Web.Migrations
{
    /// <inheritdoc />
    public partial class GridState : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b0d362a5-5eaa-47cd-92e7-8a8c4ea6e4a8");

            migrationBuilder.CreateTable(
                name: "GridStates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    GridName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Options = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GridStates", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "25d1f761-de81-4ecc-b002-28cc3c54d880", 0, "00f34567-4c6f-44f4-9d31-16fe119f76f5", null, false, false, null, "wnvko", null, null, "AQAAAAEAACcQAAAAELcd9wqkbILQQCsB60GgUqbe6xuYKF7mncyuYSjtp0KcHw40IJVNjNxdbKXA6gJFpA==", null, false, 0, "dc5937f6-9dce-4a3f-b11d-4a9fa79a1f40", false, "wnvko" });

            migrationBuilder.CreateIndex(
                name: "IX_GridStates_GridName",
                table: "GridStates",
                column: "GridName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GridStates");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "25d1f761-de81-4ecc-b002-28cc3c54d880");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b0d362a5-5eaa-47cd-92e7-8a8c4ea6e4a8", 0, "10392629-5605-4492-8a3a-49a9bf2c95ac", null, false, false, null, "wnvko", null, null, "AQAAAAEAACcQAAAAEP6OdXFyVcj75rqJflfBbwho/L0IYKdc314pVNVIOLhjrrUxnab9dlobhrIwYF7lFQ==", null, false, 0, "1196b76e-3128-4571-9864-e28fac5c1cf8", false, "wnvko" });
        }
    }
}

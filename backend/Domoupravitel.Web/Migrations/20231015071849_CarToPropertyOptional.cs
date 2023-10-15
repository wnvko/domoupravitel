using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domoupravitel.Web.Migrations
{
    /// <inheritdoc />
    public partial class CarToPropertyOptional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Properties_PropertyId",
                table: "Cars");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8d34ec4f-7b9e-4854-8a52-2c7f7f692b65");

            migrationBuilder.AlterColumn<Guid>(
                name: "PropertyId",
                table: "Cars",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c449c722-6ea9-4b1d-a881-2c0054874791", 0, "dba36249-c95f-475d-847b-ec3320757a77", null, false, false, null, "wnvko", null, null, "AQAAAAEAACcQAAAAEJHhTR/vQMXwq0ZQBLk3IorZoojIG7l5QSDkoUeZnLXKmw+VAxwYJor89WeX+UZ4UQ==", null, false, 0, "ed79faed-ddbb-4e99-9e95-30af0b8c1201", false, "wnvko" });

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Properties_PropertyId",
                table: "Cars",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Properties_PropertyId",
                table: "Cars");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "c449c722-6ea9-4b1d-a881-2c0054874791");

            migrationBuilder.AlterColumn<Guid>(
                name: "PropertyId",
                table: "Cars",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8d34ec4f-7b9e-4854-8a52-2c7f7f692b65", 0, "68112ff1-a88b-4450-819f-37287de08596", null, false, false, null, "wnvko", null, null, "AQAAAAEAACcQAAAAEKIE3KnTwzO+h6X1HQ0uJG1xOpdy8AxN6u2jijOSet/X1KbgY/6X8VCLSe5ZEV6APw==", null, false, 0, "024ec095-25eb-4938-ba93-26a26bc3c1dd", false, "wnvko" });

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Properties_PropertyId",
                table: "Cars",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

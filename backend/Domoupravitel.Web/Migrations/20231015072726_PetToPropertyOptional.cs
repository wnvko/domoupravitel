using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domoupravitel.Web.Migrations
{
    /// <inheritdoc />
    public partial class PetToPropertyOptional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Properties_PropertyId",
                table: "Pets");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "c449c722-6ea9-4b1d-a881-2c0054874791");

            migrationBuilder.AlterColumn<Guid>(
                name: "PropertyId",
                table: "Pets",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3f4f88ad-0c3d-4a6d-8231-88fb05cafc95", 0, "2f15d7a3-c42e-4899-95d7-415f1de76579", null, false, false, null, "wnvko", null, null, "AQAAAAEAACcQAAAAEHox7dl4wazsYIio/CwWKNi44b1HVEBBBaOuel5OYv9hZmViCumRDVr+5Z5hIEnl3g==", null, false, 0, "be5779a2-1b68-4e85-9f21-2590efe76a37", false, "wnvko" });

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Properties_PropertyId",
                table: "Pets",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Properties_PropertyId",
                table: "Pets");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3f4f88ad-0c3d-4a6d-8231-88fb05cafc95");

            migrationBuilder.AlterColumn<Guid>(
                name: "PropertyId",
                table: "Pets",
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
                values: new object[] { "c449c722-6ea9-4b1d-a881-2c0054874791", 0, "dba36249-c95f-475d-847b-ec3320757a77", null, false, false, null, "wnvko", null, null, "AQAAAAEAACcQAAAAEJHhTR/vQMXwq0ZQBLk3IorZoojIG7l5QSDkoUeZnLXKmw+VAxwYJor89WeX+UZ4UQ==", null, false, 0, "ed79faed-ddbb-4e99-9e95-30af0b8c1201", false, "wnvko" });

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Properties_PropertyId",
                table: "Pets",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

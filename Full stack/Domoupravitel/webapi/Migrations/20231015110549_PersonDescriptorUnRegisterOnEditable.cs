using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class PersonDescriptorUnRegisterOnEditable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3f4f88ad-0c3d-4a6d-8231-88fb05cafc95");

            migrationBuilder.AddColumn<DateTime>(
                name: "UnRegisteredOn",
                table: "Descriptors",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2d5632d0-9753-410c-843f-f756508020d3", 0, "21cc62f9-1ff7-45d7-bd73-8d1af6bae871", null, false, false, null, "wnvko", null, null, "AQAAAAEAACcQAAAAEN7mOHbyWVlYUdeVXJEGRmKScsEsGJSxSGF50nUCOZLu3F3lLCTmWtLK/akvjZhj2g==", null, false, 0, "cc243d2a-7a14-4d4e-a1bf-3f1fed04e009", false, "wnvko" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2d5632d0-9753-410c-843f-f756508020d3");

            migrationBuilder.DropColumn(
                name: "UnRegisteredOn",
                table: "Descriptors");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3f4f88ad-0c3d-4a6d-8231-88fb05cafc95", 0, "2f15d7a3-c42e-4899-95d7-415f1de76579", null, false, false, null, "wnvko", null, null, "AQAAAAEAACcQAAAAEHox7dl4wazsYIio/CwWKNi44b1HVEBBBaOuel5OYv9hZmViCumRDVr+5Z5hIEnl3g==", null, false, 0, "be5779a2-1b68-4e85-9f21-2590efe76a37", false, "wnvko" });
        }
    }
}

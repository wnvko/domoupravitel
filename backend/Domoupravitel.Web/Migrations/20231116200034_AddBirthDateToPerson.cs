using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domoupravitel.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddBirthDateToPerson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "387f5fa7-b6c8-49a7-b048-944ae4b37a6c");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "People",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "28c8b21b-b7e3-4fcf-9cde-7be98e51fd07", 0, "05f52674-4ee1-471a-a36c-56c6fd82b5f2", null, false, false, null, "wnvko", null, null, "AQAAAAEAACcQAAAAEDk4aOXGVW6/0rn7xs0s7d+HaunmoTHpYDHAxd3AbIlemEfPzJ3hjSR/GCynlhASZQ==", null, false, 0, "b8bb0336-06e0-4bbc-ba13-7a4eef03b3f0", false, "wnvko" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "28c8b21b-b7e3-4fcf-9cde-7be98e51fd07");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "People");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "387f5fa7-b6c8-49a7-b048-944ae4b37a6c", 0, "6f5684fb-1336-4bd5-9e7e-8d6c1e72d64c", null, false, false, null, "wnvko", null, null, "AQAAAAEAACcQAAAAEPsM3O+cxPqSfhaFbEIo/KaD6ktEGOSoIQIY3tL+mR6nzfO/tfKeAnNEx1G8GBORyA==", null, false, 0, "352190c1-8ece-4e4d-92c5-953c3bb36f94", false, "wnvko" });
        }
    }
}

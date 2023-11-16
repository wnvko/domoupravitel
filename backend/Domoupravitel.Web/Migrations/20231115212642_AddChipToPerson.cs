using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domoupravitel.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddChipToPerson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "78874899-de65-4c3f-b238-52e32ccbebbb");

            migrationBuilder.AddColumn<bool>(
                name: "HasChip",
                table: "People",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "387f5fa7-b6c8-49a7-b048-944ae4b37a6c", 0, "6f5684fb-1336-4bd5-9e7e-8d6c1e72d64c", null, false, false, null, "wnvko", null, null, "AQAAAAEAACcQAAAAEPsM3O+cxPqSfhaFbEIo/KaD6ktEGOSoIQIY3tL+mR6nzfO/tfKeAnNEx1G8GBORyA==", null, false, 0, "352190c1-8ece-4e4d-92c5-953c3bb36f94", false, "wnvko" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "387f5fa7-b6c8-49a7-b048-944ae4b37a6c");

            migrationBuilder.DropColumn(
                name: "HasChip",
                table: "People");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "78874899-de65-4c3f-b238-52e32ccbebbb", 0, "fb8fc34d-3319-42cc-8da0-08a78a69166f", null, false, false, null, "wnvko", null, null, "AQAAAAEAACcQAAAAEKDhSvnXWjAZTIS6tCB28J6CS21S1n/DpFUGWn2r5n2dQnVmGbZX+I6eIVH7lzISlQ==", null, false, 0, "16a4ecf7-c503-4a76-834a-2b3dac5a1fba", false, "wnvko" });
        }
    }
}

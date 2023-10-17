using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class UserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "664598dc-2233-4715-8c3c-71ce137bd6eb");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1725d11c-f721-4ad5-a97a-593237e26f6e", 0, "35a14008-a2d5-4480-b37f-561342b423eb", null, false, false, null, "wnvko", null, null, "AQAAAAEAACcQAAAAEHi2FfXhTNNFnnevOrrcvawiUavgqmO8w01saZX5vlZT6qQxr6NRRtfBQMYWohEs1Q==", null, false, 0, "0d7840cc-1ce6-4e11-a369-6ede71cdd1f2", false, "wnvko" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1725d11c-f721-4ad5-a97a-593237e26f6e");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "664598dc-2233-4715-8c3c-71ce137bd6eb", 0, "4dc4b72b-98f3-4dce-ad70-8f4e27791781", null, false, false, null, "wnvko", null, null, "AQAAAAEAACcQAAAAEMHtl7LSLQzBOKjuAheCD+OkKTY/6uSYv5L0HCQeLDe1yjNJcyqeUYtxRjki+2EVJA==", null, false, "d3b8d137-00f0-4a87-9e4f-94c943782491", false, "wnvko" });
        }
    }
}

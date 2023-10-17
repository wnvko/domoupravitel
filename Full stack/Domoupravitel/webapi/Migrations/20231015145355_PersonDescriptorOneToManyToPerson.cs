using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class PersonDescriptorOneToManyToPerson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Descriptors_People_PersonId",
                table: "Descriptors");

            migrationBuilder.DropIndex(
                name: "IX_Descriptors_PersonId",
                table: "Descriptors");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2d5632d0-9753-410c-843f-f756508020d3");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "54d99be3-4d50-4683-b0e2-e0b05a0442d9", 0, "518f30d7-b99e-456f-8e35-ce1329fcc449", null, false, false, null, "wnvko", null, null, "AQAAAAEAACcQAAAAEEd1cw/Obf8SAju+mdr3La1pOJdHT9n+MPn2fumjFFlP+5tm4QrPHhR+qNbC1qiwqA==", null, false, 0, "79834631-4915-4b55-97d7-6d58bed321a9", false, "wnvko" });

            migrationBuilder.CreateIndex(
                name: "IX_Descriptors_PersonId",
                table: "Descriptors",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Descriptors_People_PersonId",
                table: "Descriptors");

            migrationBuilder.DropIndex(
                name: "IX_Descriptors_PersonId",
                table: "Descriptors");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "54d99be3-4d50-4683-b0e2-e0b05a0442d9");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2d5632d0-9753-410c-843f-f756508020d3", 0, "21cc62f9-1ff7-45d7-bd73-8d1af6bae871", null, false, false, null, "wnvko", null, null, "AQAAAAEAACcQAAAAEN7mOHbyWVlYUdeVXJEGRmKScsEsGJSxSGF50nUCOZLu3F3lLCTmWtLK/akvjZhj2g==", null, false, 0, "cc243d2a-7a14-4d4e-a1bf-3f1fed04e009", false, "wnvko" });

            migrationBuilder.CreateIndex(
                name: "IX_Descriptors_PersonId",
                table: "Descriptors",
                column: "PersonId",
                unique: true);
        }
    }
}

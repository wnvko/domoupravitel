using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class PersonDescriptorNullableDates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "54d99be3-4d50-4683-b0e2-e0b05a0442d9");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UnRegisteredOn",
                table: "Descriptors",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisteredOn",
                table: "Descriptors",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "78874899-de65-4c3f-b238-52e32ccbebbb", 0, "fb8fc34d-3319-42cc-8da0-08a78a69166f", null, false, false, null, "wnvko", null, null, "AQAAAAEAACcQAAAAEKDhSvnXWjAZTIS6tCB28J6CS21S1n/DpFUGWn2r5n2dQnVmGbZX+I6eIVH7lzISlQ==", null, false, 0, "16a4ecf7-c503-4a76-834a-2b3dac5a1fba", false, "wnvko" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "78874899-de65-4c3f-b238-52e32ccbebbb");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UnRegisteredOn",
                table: "Descriptors",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisteredOn",
                table: "Descriptors",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "54d99be3-4d50-4683-b0e2-e0b05a0442d9", 0, "518f30d7-b99e-456f-8e35-ce1329fcc449", null, false, false, null, "wnvko", null, null, "AQAAAAEAACcQAAAAEEd1cw/Obf8SAju+mdr3La1pOJdHT9n+MPn2fumjFFlP+5tm4QrPHhR+qNbC1qiwqA==", null, false, 0, "79834631-4915-4b55-97d7-6d58bed321a9", false, "wnvko" });
        }
    }
}

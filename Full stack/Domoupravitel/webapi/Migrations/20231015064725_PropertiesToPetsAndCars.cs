using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class PropertiesToPetsAndCars : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Properties_PropertyId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Properties_PropertyId",
                table: "Pets");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "bfac8019-44df-4c36-8091-2a3006c52305");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Properties_PropertyId",
                table: "Pets",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Properties_PropertyId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Properties_PropertyId",
                table: "Pets");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8d34ec4f-7b9e-4854-8a52-2c7f7f692b65");

            migrationBuilder.AlterColumn<Guid>(
                name: "PropertyId",
                table: "Pets",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

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
                values: new object[] { "bfac8019-44df-4c36-8091-2a3006c52305", 0, "11a40354-ec1a-4d43-9cad-12b91b626a78", null, false, false, null, "wnvko", null, null, "AQAAAAEAACcQAAAAEEseB4gYS0rcYsj/0Gwu6JkVALCIVMxLlL2A1mUjgl5BwDir7Pws7GX3L5y9s4HrKQ==", null, false, 0, "692dda41-5752-44fa-9f51-47b1e6beb49f", false, "wnvko" });

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Properties_PropertyId",
                table: "Cars",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Properties_PropertyId",
                table: "Pets",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id");
        }
    }
}

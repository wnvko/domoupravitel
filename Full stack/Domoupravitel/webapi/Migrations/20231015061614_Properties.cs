using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class Properties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "5bff0612-b55a-4416-9739-40603442980d");

            migrationBuilder.AddColumn<Guid>(
                name: "PropertyId",
                table: "Pets",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "PropertyId",
                table: "Cars",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Share = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Descriptors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PersonId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PropertyId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Residence = table.Column<int>(type: "int", nullable: false),
                    MonthsInHouse = table.Column<int>(type: "int", nullable: false),
                    RegisteredOn = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descriptors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Descriptors_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Descriptors_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bfac8019-44df-4c36-8091-2a3006c52305", 0, "11a40354-ec1a-4d43-9cad-12b91b626a78", null, false, false, null, "wnvko", null, null, "AQAAAAEAACcQAAAAEEseB4gYS0rcYsj/0Gwu6JkVALCIVMxLlL2A1mUjgl5BwDir7Pws7GX3L5y9s4HrKQ==", null, false, 0, "692dda41-5752-44fa-9f51-47b1e6beb49f", false, "wnvko" });

            migrationBuilder.CreateIndex(
                name: "IX_Pets_PropertyId",
                table: "Pets",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_PropertyId",
                table: "Cars",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Descriptors_PersonId",
                table: "Descriptors",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Descriptors_PropertyId",
                table: "Descriptors",
                column: "PropertyId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Properties_PropertyId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Properties_PropertyId",
                table: "Pets");

            migrationBuilder.DropTable(
                name: "Descriptors");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Pets_PropertyId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Cars_PropertyId",
                table: "Cars");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "bfac8019-44df-4c36-8091-2a3006c52305");

            migrationBuilder.DropColumn(
                name: "PropertyId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "PropertyId",
                table: "Cars");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5bff0612-b55a-4416-9739-40603442980d", 0, "0f074e9e-9afc-411a-a9b2-770d0b2543c9", null, false, false, null, "wnvko", null, null, "AQAAAAEAACcQAAAAENwCNCTHf0WdMVd51f0Wq7kWt9E8l3RF0SpQWSFZVSJAGGtWDgta6DQNw4K93265UQ==", null, false, 0, "9e355361-fd11-4716-aba3-965a9d200781", false, "wnvko" });
        }
    }
}

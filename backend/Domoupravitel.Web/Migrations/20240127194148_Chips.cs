using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domoupravitel.Web.Migrations
{
    /// <inheritdoc />
    public partial class Chips : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "28c8b21b-b7e3-4fcf-9cde-7be98e51fd07");

            migrationBuilder.DropColumn(
                name: "HasChip",
                table: "People");

            migrationBuilder.CreateTable(
                name: "Chips",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Number = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Disabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PersonId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chips_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b0d362a5-5eaa-47cd-92e7-8a8c4ea6e4a8", 0, "10392629-5605-4492-8a3a-49a9bf2c95ac", null, false, false, null, "wnvko", null, null, "AQAAAAEAACcQAAAAEP6OdXFyVcj75rqJflfBbwho/L0IYKdc314pVNVIOLhjrrUxnab9dlobhrIwYF7lFQ==", null, false, 0, "1196b76e-3128-4571-9864-e28fac5c1cf8", false, "wnvko" });

            migrationBuilder.CreateIndex(
                name: "IX_Chips_PersonId",
                table: "Chips",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chips");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b0d362a5-5eaa-47cd-92e7-8a8c4ea6e4a8");

            migrationBuilder.AddColumn<bool>(
                name: "HasChip",
                table: "People",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "28c8b21b-b7e3-4fcf-9cde-7be98e51fd07", 0, "05f52674-4ee1-471a-a36c-56c6fd82b5f2", null, false, false, null, "wnvko", null, null, "AQAAAAEAACcQAAAAEDk4aOXGVW6/0rn7xs0s7d+HaunmoTHpYDHAxd3AbIlemEfPzJ3hjSR/GCynlhASZQ==", null, false, 0, "b8bb0336-06e0-4bbc-ba13-7a4eef03b3f0", false, "wnvko" });
        }
    }
}

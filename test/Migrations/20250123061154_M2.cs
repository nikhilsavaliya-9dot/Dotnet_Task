using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace test.Migrations
{
    /// <inheritdoc />
    public partial class M2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoleMaster",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleName = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleMaster", x => x.RoleId);
                });

            migrationBuilder.UpdateData(
                table: "CompanyInfo",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 23, 6, 11, 53, 648, DateTimeKind.Utc).AddTicks(5445), new DateTime(2025, 1, 23, 6, 11, 53, 648, DateTimeKind.Utc).AddTicks(5445) });

            migrationBuilder.InsertData(
                table: "RoleMaster",
                columns: new[] { "RoleId", "CreatedDate", "Description", "RoleName" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 23, 6, 11, 53, 648, DateTimeKind.Utc).AddTicks(5546), "Administrator with full access", "Admin" },
                    { 2, new DateTime(2025, 1, 23, 6, 11, 53, 648, DateTimeKind.Utc).AddTicks(5549), "Regular user with standard access", "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleMaster");

            migrationBuilder.UpdateData(
                table: "CompanyInfo",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 23, 6, 0, 13, 295, DateTimeKind.Utc).AddTicks(2769), new DateTime(2025, 1, 23, 6, 0, 13, 295, DateTimeKind.Utc).AddTicks(2770) });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace test.Migrations
{
    /// <inheritdoc />
    public partial class M1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompanyName = table.Column<string>(type: "text", nullable: false),
                    AcquisitionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PlatformFeatures = table.Column<string>(type: "text", nullable: false),
                    IpAddressV4 = table.Column<string>(type: "text", nullable: false),
                    MacAddress = table.Column<string>(type: "text", nullable: false),
                    Canceled = table.Column<bool>(type: "boolean", nullable: false),
                    Suspended = table.Column<bool>(type: "boolean", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    ApiBaseUrl = table.Column<string>(type: "text", nullable: false),
                    DemoAccountNodeId = table.Column<int>(type: "integer", nullable: false),
                    AndroidBuild = table.Column<string>(type: "text", nullable: false),
                    ForceUpgrade = table.Column<bool>(type: "boolean", nullable: false),
                    iOSBuild = table.Column<string>(type: "text", nullable: false),
                    AccountsCreatorURL = table.Column<string>(type: "text", nullable: false),
                    WhatsNew = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    LogoUrl = table.Column<string>(type: "text", nullable: true),
                    WebsiteUrl = table.Column<string>(type: "text", nullable: true),
                    FacebookUrl = table.Column<string>(type: "text", nullable: true),
                    YouTubeUrl = table.Column<string>(type: "text", nullable: true),
                    LinkedInUrl = table.Column<string>(type: "text", nullable: true),
                    XUrl = table.Column<string>(type: "text", nullable: true),
                    ContactNumber = table.Column<string>(type: "text", nullable: true),
                    HelpPageUrl = table.Column<string>(type: "text", nullable: true),
                    PrivacyPolicyUrl = table.Column<string>(type: "text", nullable: true),
                    TermsOfServiceUrl = table.Column<string>(type: "text", nullable: true),
                    PhysicalAddress = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PhoneNo = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsDelete = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "CompanyInfo",
                columns: new[] { "Id", "AccountsCreatorURL", "AcquisitionDate", "Address", "AndroidBuild", "ApiBaseUrl", "Canceled", "CompanyName", "ContactNumber", "CreatedAt", "DemoAccountNodeId", "Email", "FacebookUrl", "ForceUpgrade", "HelpPageUrl", "IpAddressV4", "LinkedInUrl", "LogoUrl", "MacAddress", "PhysicalAddress", "PlatformFeatures", "PrivacyPolicyUrl", "Suspended", "TermsOfServiceUrl", "UpdatedAt", "WebsiteUrl", "WhatsNew", "XUrl", "YouTubeUrl", "iOSBuild" },
                values: new object[] { 1, "https://accounts.9dottech.com", new DateTime(2022, 8, 14, 18, 30, 0, 0, DateTimeKind.Utc), "456 Innovation Avenue, Tech Park", "3.2.1", "https://api.9dottech.com", false, "9dot Technology", "+1-800-999-4567", new DateTime(2025, 1, 23, 6, 0, 13, 295, DateTimeKind.Utc).AddTicks(2769), 909, "contact@9dottech.com", "https://facebook.com/9dottech", true, "https://9dottech.com/help", "192.168.9.9", "https://linkedin.com/company/9dottech", "https://9dottech.com/logo.png", "00-1A-2B-3C-4D-5E", "456 Innovation Avenue, Tech Park", "Analytics, Automation, Cloud Solutions", "https://9dottech.com/privacy", false, "https://9dottech.com/terms", new DateTime(2025, 1, 23, 6, 0, 13, 295, DateTimeKind.Utc).AddTicks(2770), "https://9dottech.com", "New dashboard design and enhanced security", "https://x.com/9dottech", "https://youtube.com/9dottech", "4.0.0" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Email", "FullName", "IsActive", "IsDelete", "Password", "PhoneNo", "RoleId" },
                values: new object[] { 1, "admin@yopmail.com", "Admin", true, false, "Admin@123", "8744125833", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyInfo");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}

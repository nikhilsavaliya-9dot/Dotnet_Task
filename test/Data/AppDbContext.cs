using Microsoft.EntityFrameworkCore;
using test.Enums;
using test.Models;
using V2AccountCRM.Models;

namespace test.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<CompanyInfo> CompanyInfo { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<RoleMaster> RoleMaster { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CompanyInfo>().HasData(
                 new CompanyInfo
                 {
                     Id = 1,
                     CompanyName = "9dot Technology",
                     AcquisitionDate = new DateTime(2022, 8, 15).ToUniversalTime(),
                     PlatformFeatures = "Analytics, Automation, Cloud Solutions",
                     IpAddressV4 = "192.168.9.9",
                     MacAddress = "00-1A-2B-3C-4D-5E",
                     Canceled = false,
                     Suspended = false,
                     Email = "contact@9dottech.com",
                     ApiBaseUrl = "https://api.9dottech.com",
                     DemoAccountNodeId = 909,
                     AndroidBuild = "3.2.1",
                     ForceUpgrade = true,
                     iOSBuild = "4.0.0",
                     AccountsCreatorURL = "https://accounts.9dottech.com",
                     WhatsNew = "New dashboard design and enhanced security",
                     Address = "456 Innovation Avenue, Tech Park",
                     LogoUrl = "https://9dottech.com/logo.png",
                     WebsiteUrl = "https://9dottech.com",
                     FacebookUrl = "https://facebook.com/9dottech",
                     YouTubeUrl = "https://youtube.com/9dottech",
                     LinkedInUrl = "https://linkedin.com/company/9dottech",
                     XUrl = "https://x.com/9dottech",
                     ContactNumber = "+1-800-999-4567",
                     HelpPageUrl = "https://9dottech.com/help",
                     PrivacyPolicyUrl = "https://9dottech.com/privacy",
                     TermsOfServiceUrl = "https://9dottech.com/terms",
                     PhysicalAddress = "456 Innovation Avenue, Tech Park",
                     CreatedAt = DateTime.UtcNow,
                     UpdatedAt = DateTime.UtcNow
                 }
             );

            modelBuilder.Entity<User>().HasData(
                 new User
                 {
                     UserId = 1,
                     FullName = "Admin",
                     Email = "admin@yopmail.com",
                     PhoneNo = "8744125833",
                     Password = "R/fmAZyZOsgvjGYMEwqWHQ==",
                     RoleId = RoleType.Admin,
                     IsActive = true,
                     IsDelete = false
                 }
            );

            modelBuilder.Entity<RoleMaster>().HasData(
                new RoleMaster { RoleId = (int)RoleType.Admin, RoleName = RoleType.Admin.ToString(), Description = "Administrator with full access" },
                new RoleMaster { RoleId = (int)RoleType.User, RoleName = RoleType.User.ToString(), Description = "User with limited access" }
            );
        }
    }
}

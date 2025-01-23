using System.ComponentModel.DataAnnotations;

namespace test.Models
{
    public class CompanyInfo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public DateTime AcquisitionDate { get; set; }
        [Required]
        public string PlatformFeatures { get; set; }
        [Required]
        public string IpAddressV4 { get; set; }
        [Required]
        public string MacAddress { get; set; }
        [Required]
        public bool Canceled { get; set; }
        [Required]
        public bool Suspended { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string ApiBaseUrl { get; set; }
        [Required]
        public int DemoAccountNodeId { get; set; }
        [Required]
        public string AndroidBuild { get; set; }
        [Required]
        public bool ForceUpgrade { get; set; }
        [Required]
        public string iOSBuild { get; set; }
        [Required]
        public string AccountsCreatorURL { get; set; }
        [Required]
        public string WhatsNew { get; set; }
        [Required]
        public string Address { get; set; }

        // Optional
        public string? LogoUrl { get; set; }
        public string? WebsiteUrl { get; set; }
        public string? FacebookUrl { get; set; }
        public string? YouTubeUrl { get; set; }
        public string? LinkedInUrl { get; set; }
        public string? XUrl { get; set; } 
        public string? ContactNumber { get; set; }
        public string? HelpPageUrl { get; set; }
        public string? PrivacyPolicyUrl { get; set; }
        public string? TermsOfServiceUrl { get; set; }
        public string? PhysicalAddress { get; set; }

        // Timestamps
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; } 
    }
}

using System.ComponentModel.DataAnnotations;
using test.Enums;

namespace test.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string? FullName { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        [StringLength(15, MinimumLength = 7, ErrorMessage = "Please enter a valid phone number")]
        public string? PhoneNo { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        public RoleType RoleId { get; set; }

        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}

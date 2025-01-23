using System.ComponentModel.DataAnnotations;

namespace test.ViewModel
{
    public class LoginRequest
    {
        private string _email;

        [Required(ErrorMessage = "Please enter a valid email address.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email address.")]
        public string Email
        {
            get { return _email; }
            set { _email = value?.ToLower().Trim(); } // Convert to lowercase before setting
        }


        [Required(ErrorMessage = "Please enter password")]
        public string? Password { get; set; }


    }
}

namespace test.ViewModel
{
    public class LoginResponse
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string? AuthToken { get; set; }
        public string? Role { get; set; }
        public int ExpiredIn { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? MobileNo { get; set; }
        public bool IsActive { get; set; }
    }
}

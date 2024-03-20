namespace Herfitk_Dashboard.Models
{
    public class RegisterViewModel
    {
        public string DisplayName { get; set; }
        public string? Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string NationalId { get; set; }
        public int? RoleId { get; set; }
        public IFormFile? PersonalImage { get; set; }
        public IFormFile? NationalIdImage { get; set; }
    }
}

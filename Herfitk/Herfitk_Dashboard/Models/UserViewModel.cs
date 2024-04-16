namespace Herfitk_Dashboard.Models
{
    public class UserViewModel
    {
        public string DisplayName { get; set; }
        public string? Address { get; set; }
        public string NationalId { get; set; }
        public IFormFile? PersonalImage { get; set; }
        public IFormFile? NationalIdImage { get; set; }
        public int? UserRoleID { get; set; }
    }
}
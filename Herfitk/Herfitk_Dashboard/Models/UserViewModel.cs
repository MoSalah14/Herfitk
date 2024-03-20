namespace Herfitk_Dashboard.Models
{
    public class UserViewModel
    {
        public string DisplayName { get; set; }
        public string? Address { get; set; }
        public string NationalId { get; set; }
        public string? PersonalImage { get; set; }
        public string? NationalIdImage { get; set; }
        public string? AccountState { get; set; }
        public int? UserRoleID { get; set; }
    }
}

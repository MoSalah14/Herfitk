using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Herfitk_Dashboard.Models
{
    public class RegisterViewModel
    {
        public int Id { get; set; }
        [DisplayName("Name")]
        [Required]
        public string DisplayName { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [RegularExpression(@"^[\w-\.]+@(?:(?:gmail|outlook|yahoo)\.com)$", ErrorMessage = "Email must contain '@' and end with gmail.com, outlook.com, or yahoo.com")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^011\d{9}$", ErrorMessage = "Phone number must start with '01' and contain 11 digits.")]
        public string PhoneNumber { get; set; }
        public string? Password { get; set; }
        [Required(ErrorMessage = "National ID is required")]
        [RegularExpression(@"^\d{14}$", ErrorMessage = "National ID must be exactly 14 digits")]
        public string NationalId { get; set; }
        public int? RoleId { get; set; }
        public IFormFile? PersonalImage { get; set; }
        public IFormFile? NationalIdImage { get; set; }
    }
}

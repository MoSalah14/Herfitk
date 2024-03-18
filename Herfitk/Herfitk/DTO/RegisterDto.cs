using System.ComponentModel.DataAnnotations;

namespace Herfitk.API.Dto
{
    public class RegisterDto
    {
        [Required]
        public string DisplayName { get; set; }
        public string? Address { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]

        public string PhoneNumber { get; set; }
        [Required]
        [RegularExpression("^(?:(?=.*[a-z])(?:(?=.*[A-Z])(?=.*[\\d\\W])|(?=.*\\W)(?=.*\\d))|(?=.*\\W)(?=.*[A-Z])(?=.*\\d)).{8,}$",
                          ErrorMessage = "Password Is Not Valid")]
        public string Password { get; set; }

        [StringLength(14, MinimumLength = 14, ErrorMessage = "National ID must Be 14 characters")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "National ID must contain only numeric characters")]
        public string NationalId { get; set; }
        public IFormFile? PersonalImage { get; set; }


        public IFormFile? NationalIdImage { get; set; }


    }
}

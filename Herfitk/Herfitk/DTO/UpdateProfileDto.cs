using System.ComponentModel.DataAnnotations;

namespace Herfitk.API.DTO
{
    public class UpdateProfileDto
    {
        public string DisplayName { get; set; }
        public string? Address { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}

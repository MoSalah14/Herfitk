using System.ComponentModel.DataAnnotations;

namespace Herfitk.API.DTO
{
    public class ResetUserPassword
    {
        [Required(ErrorMessage = "Password is Requierd")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "ConfirmPassword is Requierd")]
        [Compare("NewPassword", ErrorMessage = "Confirm Password does Not Match Password")]
        public string ConfirmPassword { get; set; }

        public string Token { get; set; }
        public string Email { get; set; }
    }
}
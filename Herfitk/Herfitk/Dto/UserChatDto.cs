using System.ComponentModel.DataAnnotations;

namespace Herfitk.API.Dto
{
    public class UserChatDto
    {
        [Required]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Name Must Be More Than 3 Character")]
        public string Name { get; set; }
    }
}
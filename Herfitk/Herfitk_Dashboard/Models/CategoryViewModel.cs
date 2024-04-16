using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Herfitk_Dashboard.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [DisplayName("Name")]
        public string? CategoryName { get; set; }

        [Required(ErrorMessage = "Description is Required")]
        public string? Descraption { get; set; }

        public IFormFile? Image { get; set; }
    }
}

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Herfitk_Dashboard.Models
{
    public class StaffViewModel
    {
		[DisplayName("Staff Id")]
		public int Id { get; set; }
        [Required]
        public decimal? Salary { get; set; }
		[Required]
		[DisplayName("Hire Date")]
		public DateOnly? HireDate { get; set; }
		[Required]
		[DisplayName("Work Hours")]
		public int? WorkHours { get; set; }
		[Required]
		[DisplayName("User Id")]
		public int UserId { get; set; }
    }
}

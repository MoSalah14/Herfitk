namespace Herfitk_Dashboard.Models
{
    public class StaffViewModel
    {
        public int Id { get; set; }
        public decimal? Salary { get; set; }

        public DateOnly? HireDate { get; set; }
        public int? WorkHours { get; set; }
        public int UserId { get; set; }
    }
}

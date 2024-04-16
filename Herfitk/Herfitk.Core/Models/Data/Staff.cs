namespace Herfitk.Core.Models.Data;

public partial class Staff
{
    public int Id { get; set; }

    public decimal? Salary { get; set; }

    public DateOnly? HireDate { get; set; }

    public int? WorkHours { get; set; }

    public int UserId { get; set; }

    public virtual AppUser? StaffUser { get; set; }
}
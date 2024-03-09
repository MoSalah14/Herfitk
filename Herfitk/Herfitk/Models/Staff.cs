using System;
using System.Collections.Generic;

namespace Herfitk.Models;

public partial class Staff
{
    public int Id { get; set; }

    public decimal? Salary { get; set; }

    public DateOnly? HireDate { get; set; }

    public int? WorkHours { get; set; }

    public int? UserId { get; set; }

    public virtual User? User { get; set; }
}

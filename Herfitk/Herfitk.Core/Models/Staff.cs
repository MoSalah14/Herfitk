using Herfitk.Core.Models;
using Herfitk.Core.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Herfitk.Models;

public partial class Staff
{
    public int Id { get; set; }

    public decimal? Salary { get; set; }

    public DateOnly? HireDate { get; set; }

    public int? WorkHours { get; set; }

    public int? UserId { get; set; }
    [NotMapped]

    public virtual HerifyAppUser? User { get; set; }
}

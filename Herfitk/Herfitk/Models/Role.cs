using System;
using System.Collections.Generic;

namespace Herfitk.Models;

public partial class Role
{
    public int Id { get; set; }

    public string? Type { get; set; }

    public int? UserId { get; set; }

    public virtual User? User { get; set; }
}

using System;
using System.Collections.Generic;

namespace Herfitk.Models;

public partial class HerifyCategory
{
    public int? HerifyId { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Herfiy? Herify { get; set; }
}

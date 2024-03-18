using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Herfitk.Core.Models.Data;

public partial class HerifyCategory
{
    public int HerifyId { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; }

    public virtual Herfiy Herify { get; set; }
}

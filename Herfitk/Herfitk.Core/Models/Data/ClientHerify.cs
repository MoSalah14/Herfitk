using System;
using System.Collections.Generic;

namespace Herfitk.Core.Models.Data;

public partial class ClientHerify
{
    public int Id { get; set; }

    public DateOnly Date { get; set; }
    public string? ClientReview { get; set; }

    public int? ClientId { get; set; }

    public int? Rate { get; set; }
    public int? HerifyId { get; set; }

    public virtual Client? Client { get; set; }

    public virtual Herfiy? Herify { get; set; }
}

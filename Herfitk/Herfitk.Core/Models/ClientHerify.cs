using System;
using System.Collections.Generic;

namespace Herfitk.Models;

public partial class ClientHerify
{
    public int Id { get; set; }

    public decimal? Cost { get; set; }

    public DateOnly? Date { get; set; }

    public string? State { get; set; }

    public string? ClientReview { get; set; }

    public string? HerifyReview { get; set; }

    public int? ClientId { get; set; }

    public int? HerifyId { get; set; }

    public virtual Client? Client { get; set; }

    public virtual Herfiy? Herify { get; set; }
}

using System;
using System.Collections.Generic;

namespace Herfitk.Models;

public partial class Payment
{
    public int Id { get; set; }

    public DateOnly? Date { get; set; }

    public string? State { get; set; }

    public decimal? Amount { get; set; }

    public string? PaymentTerm { get; set; }

    public int? HerifyId { get; set; }

    public virtual Herfiy? Herify { get; set; }
}

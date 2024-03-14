using System;
using System.Collections.Generic;

namespace Herfitk.Core.Models.Data;

public partial class Herfiy
{
    public int Id { get; set; }

    public string? Zone { get; set; }

    public string? History { get; set; }

    public string? Speciality { get; set; }

    public string? UserId { get; set; }

    public virtual ICollection<ClientHerify> ClientHerifies { get; set; } = new List<ClientHerify>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual AppUser? HerfiyUser { get; set; }
}

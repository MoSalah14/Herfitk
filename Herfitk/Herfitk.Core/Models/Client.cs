using Herfitk.Core.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Herfitk.Models;

public partial class Client
{
    public int Id { get; set; }

    public string? History { get; set; }

    public string? Review { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<ClientHerify> ClientHerifies { get; set; } = new List<ClientHerify>();

    [NotMapped]
    public virtual AppUser? User { get; set; }
}

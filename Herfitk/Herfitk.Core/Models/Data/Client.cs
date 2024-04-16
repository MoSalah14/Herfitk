namespace Herfitk.Core.Models.Data;

public partial class Client
{
    public int Id { get; set; }

    public string? History { get; set; }

    public string? Review { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<ClientHerify> ClientHerifies { get; set; } = new List<ClientHerify>();

    public virtual AppUser? ClientUser { get; set; }
}
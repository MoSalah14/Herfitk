using System;
using System.Collections.Generic;

namespace Herfitk.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Name { get; set; }//

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }//

    public string? Password { get; set; }

    public string? NationalId { get; set; }//

    public string? PersonalImage { get; set; }//
    
    public string? NationalIdImage { get; set; }//

    public string? AccountState { get; set; }//

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    public virtual ICollection<Herfiy> Herfiys { get; set; } = new List<Herfiy>();

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();
}

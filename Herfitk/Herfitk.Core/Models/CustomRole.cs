using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herfitk.Core.Models
{
    public class CustomRole : IdentityRole<int>
    {
        [Key]
        public int RoleID { get; set; }
    }
}

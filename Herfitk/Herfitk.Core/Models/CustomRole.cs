using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Herfitk.Core.Models
{
    public class CustomRole : IdentityRole<int>
    {
        [Key]
        public int RoleID { get; set; }
    }
}
using Herfitk.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herfitk.Core.Models.Identity
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public string? Address { get; set; }

        [StringLength(14, MinimumLength = 14, ErrorMessage = "National ID must Be 14 characters")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "National ID must contain only numeric characters")]
        public string NationalId { get; set; }

        public string? PersonalImage { get; set; }

        public string? NationalIdImage { get; set; }

        public string? AccountState { get; set; }
    }
}

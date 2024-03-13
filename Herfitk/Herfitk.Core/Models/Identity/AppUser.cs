using Herfitk.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herfitk.Core.Models.Identity
{
    public class AppUser : IdentityUser
    {
       
        public string DisplayName { get; set; }
        public string? Address { get; set; }

        public string NationalId { get; set; }

        public string? PersonalImage { get; set; }

        public string? NationalIdImage { get; set; }

        public string? AccountState { get; set; }

        
        //public  Herfiy Herfiys { get; set; }

    }
}

using Herfitk.Core.Models.Data;
using Microsoft.AspNetCore.Identity;

namespace Herfitk.Core.Models
{
    public class AppUser : IdentityUser<int>
    {
        public string DisplayName { get; set; }
        public string? Address { get; set; }

        public string NationalId { get; set; }

        public string? PersonalImage { get; set; }

        public string? NationalIdImage { get; set; }

        public string? AccountState { get; set; }
        public int? UserRoleID { get; set; }

        public virtual Herfiy? UserHerify { get; set; }
        public virtual Staff? UserStaff { get; set; }
        public virtual Client? UserClient { get; set; }

        public virtual IdentityRole<int>? Role { get; set; }
    }
}
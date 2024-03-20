using Microsoft.AspNetCore.Mvc.Rendering;

namespace Herfitk_Dashboard.Models
{
    public class HerifyViewModel
    {
        public int Id { get; set; }
        public string? Zone { get; set; }
        public string? History { get; set; }
        public string? Speciality { get; set; }
        public int UserId { get; set; }


    }
}

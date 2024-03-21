namespace Herfitk.API.DTO
{
    public class HerifyDto
    {
        public string? HerifyId { get; set; }
        public string? Zone { get; set; }

        public string? History { get; set; }

        public string? Speciality { get; set; }
        public int HerifyUserId { get; set; }

        //This for Display in DisplayPage (To Allow Convert)
        public string? DisplayImage { get; set; }

        public IFormFile? Image { get; set; }


    }
}

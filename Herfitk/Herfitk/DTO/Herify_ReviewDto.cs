namespace Herfitk.API.DTO
{
    public class Herify_ReviewDto
    {
      
        public string? Name { get; set; }
        public int? Rate { get; set; }

        public string? Review { get; set; }
        public DateOnly ReviewDate { get; set; } = DateOnly.FromDateTime(DateTime.Today);

    }
}

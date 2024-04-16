namespace Herfitk.API.DTO
{
    public class Client_ReviewReturnDto
    {
        public int ClientId { get; set; }

        public int HerifyID { get; set; }
        public int? Rate { get; set; }

        public string? Review { get; set; }
        public DateOnly ReviewDate { get; set; } = DateOnly.FromDateTime(DateTime.Today);
    }
}
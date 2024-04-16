namespace Herfitk.API.DTO
{
    public class StaffDto
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string? Address { get; set; }
        public string NationalId { get; set; }
        public DateOnly? HireDate { get; set; }
        public string? PersonalImage { get; set; }
        public int? WorkHours { get; set; }
        public string? UserRole { get; set; }
    }
}
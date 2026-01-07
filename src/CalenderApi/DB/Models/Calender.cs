namespace CalenderApi.DB.Models
{
    public class Calender
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public DateTime Date { get; set; }
        public required string Description { get; set; }
    }
}

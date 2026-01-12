using CalenderApi.DB.Models;

namespace CalenderApi.Dtos
{
    public class CalenderCreateDto
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public CalenderCreateDto MapCalenderToDto(Calender c)
        {
            var dto = new CalenderCreateDto
            {
                Title = c.Title,
                Date = c.Date,
                Description = c.Description
            };
            return dto;
        }
    }
}

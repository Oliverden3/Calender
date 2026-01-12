using CalenderApi.DB.Models;

namespace CalenderApi.Dtos
{
    public class CalenderReadDto
    {
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }

        public CalenderReadDto MapCalenderToDto(Calender c)
        {
            var dto = new CalenderReadDto
            {
                Title = c.Title,
                StartDate = c.Date,
                EndDate = c.Date,
                Description = c.Description
            };
            return dto;
        }
        public List<CalenderReadDto> MapCalenderListToDtoList(List<Calender> calenders)
        {
            var dtoList = new List<CalenderReadDto>();
            foreach (var c in calenders)
            {
                dtoList.Add(MapCalenderToDto(c));
            }
            return dtoList;
        }
    }
}

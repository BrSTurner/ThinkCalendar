using AutoMapper;
using Think.Calendar.Application.Model;
using Think.Calendar.Domain.Mediator.Commands;
using Think.Calendar.Domain.Model;

namespace Think.Calendar.Application.Profiles
{
    public class CalendarEventProfile : Profile
    {
        public CalendarEventProfile()
        {
            CreateMap<CalendarEvent, CalendarEventDTO>();
            CreateMap<AddCalendarEventCommand, CalendarEventDTO>();
            CreateMap<UpdateCalendarEventCommand, CalendarEventDTO>();
        }
    }
}

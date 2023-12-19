using Think.Calendar.Application.Model;
using Think.Calendar.Domain.Mediator.Commands;

namespace Think.Calendar.Application.Services.Interrfaces
{
    public interface ICalendarEventService
    {
        Task<CalendarEventDTO> AddNewAsync(AddCalendarEventCommand addCalendarEventCommand);
        Task<CalendarEventDTO> UpdateAsync(UpdateCalendarEventCommand updateCalendarEventCommand);
        Task<IEnumerable<CalendarEventDTO>> GetEventsByDateAsync(DateTime date);
        Task<CalendarEventDTO> GetEventByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
}

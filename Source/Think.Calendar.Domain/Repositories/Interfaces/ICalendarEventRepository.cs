using Think.Calendar.Domain.Model;

namespace Think.Calendar.Domain.Repositories.Interfaces
{
    public interface ICalendarEventRepository : IDisposable
    {
        Task<CalendarEvent> AddNewAsync(CalendarEvent calendarEvent);
        Task<CalendarEvent?> GetByIdTrackingAsync(int id);
        Task<CalendarEvent> GetEventByIdAsync(int id);
        Task<IEnumerable<CalendarEvent>> GetEventsByDateAsync(DateTime date);
        void Delete(CalendarEvent calendarEvent);
    }
}

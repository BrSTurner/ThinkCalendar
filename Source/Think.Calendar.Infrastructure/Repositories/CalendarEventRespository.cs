using Dapper;
using Microsoft.EntityFrameworkCore;
using Think.Calendar.Domain.Model;
using Think.Calendar.Domain.Repositories.Interfaces;
using Think.Calendar.Infrastructure.Data;

namespace Think.Calendar.Infrastructure.Repositories
{
    public class CalendarEventRespository : ICalendarEventRepository
    {
        private readonly ThinkCalendarContext _context;
        private readonly DbSet<CalendarEvent> _events;  
        
        public CalendarEventRespository(ThinkCalendarContext context)
        {
            _context = context;
            _events = _context.Set<CalendarEvent>();
        }

        public async Task<CalendarEvent> AddNewAsync(CalendarEvent calendarEvent)
        {
            var entity = await _events.AddAsync(calendarEvent);
            return entity.Entity;
        }

        public async Task<CalendarEvent?> GetByIdTrackingAsync(int id) => await _events.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<CalendarEvent>> GetEventsByDateAsync(DateTime date)
        {
            var startDate = date.Date;
            var endDate = date.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            var sql = $@"SELECT
                            *
                        FROM
                            CalendarEvent
                        WHERE
                            StartDate >= @Date AND StartDate <= @EndDate";

            var parameters = new
            {
                Date = startDate,
                EndDate = endDate,
            };

            return await _context.Database.GetDbConnection().QueryAsync<CalendarEvent>(sql, parameters); 
        }

        public async Task<CalendarEvent> GetEventByIdAsync(int id)
        {
            var sql = $@"SELECT
                            *
                        FROM
                            CalendarEvent
                        WHERE
                            Id=@Id";

            var parameters = new
            {
                Id=id
            };

            return await _context.Database.GetDbConnection().QuerySingleAsync<CalendarEvent>(sql, parameters);
        }
        public void Delete(CalendarEvent calendarEvent)
        {
            _events.Remove(calendarEvent);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    
    }
}

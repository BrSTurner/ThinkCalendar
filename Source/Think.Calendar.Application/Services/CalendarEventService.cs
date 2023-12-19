using Think.Calendar.Application.Model;
using Think.Calendar.Application.Services.Interrfaces;
using Think.Calendar.Domain.Mediator.Commands;
using Think.Calendar.Domain.Mediator.Interfaces;
using Think.Calendar.Domain.Model;
using Think.Calendar.Domain.Repositories.Interfaces;

namespace Think.Calendar.Application.Services
{
    public class CalendarEventService : ICalendarEventService
    {
        private readonly IMediatorHandler _mediator;
        private readonly ICalendarEventRepository _calendarEventRepository;

        public CalendarEventService(
            IMediatorHandler mediator,
            ICalendarEventRepository calendarEventRepository)
        {
            _mediator = mediator;
            _calendarEventRepository = calendarEventRepository;
        }

        public async Task<CalendarEventDTO> AddNewAsync(AddCalendarEventCommand addCalendarEventCommand)
        {
            var result = await _mediator.SendCommandAsync<AddCalendarEventCommand, CalendarEvent>(addCalendarEventCommand);

            if(result.Success && result.Data != null)
            {
                return new CalendarEventDTO
                {
                    Id = result.Data.Id,
                    Title = result.Data.Title,
                    Description = result.Data.Description,
                    StartDate = result.Data.StartDate,
                    Email = result.Data.Email,
                    EndDate = result.Data.EndDate,
                    Location = result.Data.Location                    
                };
            }

            return null;
        }

        public async Task<CalendarEventDTO> UpdateAsync(UpdateCalendarEventCommand updateCalendarEventCommand)
        {
            var result = await _mediator.SendCommandAsync<UpdateCalendarEventCommand, CalendarEvent>(updateCalendarEventCommand);

            if (result.Success && result.Data != null)
            {
                return new CalendarEventDTO
                {
                    Id = result.Data.Id,
                    Title = result.Data.Title,
                    Description = result.Data.Description,
                    StartDate = result.Data.StartDate,
                    Email = result.Data.Email,
                    EndDate = result.Data.EndDate,
                    Location = result.Data.Location
                };
            }

            return null;
        }

        public async Task<IEnumerable<CalendarEventDTO>> GetEventsByDateAsync(DateTime date)
        {
            var events = await _calendarEventRepository.GetEventsByDateAsync(date);

            if(events == null || !events.Any())
                return new List<CalendarEventDTO>();

            return events.Select(x => new CalendarEventDTO
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Location = x.Location,
                Email = x.Email
            });
        }

        public async Task<CalendarEventDTO> GetEventByIdAsync(int id)
        {
            var calendarEvent = await _calendarEventRepository.GetEventByIdAsync(id);

            if (calendarEvent == null)
                return null;

            return  new CalendarEventDTO
            {
                Id = calendarEvent.Id,
                Title = calendarEvent.Title,
                Description = calendarEvent.Description,
                StartDate = calendarEvent.StartDate,
                EndDate = calendarEvent.EndDate,
                Location = calendarEvent.Location,
                Email = calendarEvent.Email
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _mediator.SendCommandAsync<DeleteCalendarEventCommand, bool>(new DeleteCalendarEventCommand
            {
                Id = id
            });

            return result.Success && result.Data;
        }
    }
}

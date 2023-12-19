using AutoMapper;
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
        private readonly IMapper _mapper;
        public CalendarEventService(
            IMediatorHandler mediator,
            ICalendarEventRepository calendarEventRepository,
            IMapper mapper)
        {
            _mediator = mediator;
            _calendarEventRepository = calendarEventRepository;
            _mapper = mapper;
        }

        public async Task<CalendarEventDTO> AddNewAsync(AddCalendarEventCommand addCalendarEventCommand)
        {
            var result = await _mediator.SendCommandAsync<AddCalendarEventCommand, CalendarEvent>(addCalendarEventCommand);

            if(result.Success && result.Data != null)
            {
                return _mapper.Map<CalendarEventDTO>(result.Data);
            }

            return _mapper.Map<CalendarEventDTO>(addCalendarEventCommand);
        }

        public async Task<CalendarEventDTO> UpdateAsync(UpdateCalendarEventCommand updateCalendarEventCommand)
        {
            var result = await _mediator.SendCommandAsync<UpdateCalendarEventCommand, CalendarEvent>(updateCalendarEventCommand);

            if (result.Success && result.Data != null)
            {
                return _mapper.Map<CalendarEventDTO>(result.Data);
            }

            return _mapper.Map<CalendarEventDTO>(updateCalendarEventCommand);
        }

        public async Task<IEnumerable<CalendarEventDTO>> GetEventsByDateAsync(DateTime date)
        {
            var events = await _calendarEventRepository.GetEventsByDateAsync(date);

            if(events == null || !events.Any())
                return new List<CalendarEventDTO>();

            return _mapper.Map<IEnumerable<CalendarEventDTO>>(events);
        }

        public async Task<CalendarEventDTO> GetEventByIdAsync(int id)
        {
            var calendarEvent = await _calendarEventRepository.GetEventByIdAsync(id);

            if (calendarEvent == null)
                return null;

            return _mapper.Map<CalendarEventDTO>(calendarEvent);
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

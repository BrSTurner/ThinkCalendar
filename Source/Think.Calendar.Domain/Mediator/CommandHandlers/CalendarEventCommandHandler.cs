using MediatR;
using Think.Calendar.Domain.Mediator.Commands;
using Think.Calendar.Domain.Mediator.Interfaces;
using Think.Calendar.Domain.Mediator.Model;
using Think.Calendar.Domain.Mediator.Notifications;
using Think.Calendar.Domain.Model;
using Think.Calendar.Domain.Notificator.Interfaces;
using Think.Calendar.Domain.Repositories.Interfaces;
using Think.Calendar.Domain.UnitOfWork;

namespace Think.Calendar.Domain.Mediator.CommandHandlers
{
    public class CalendarEventCommandHandler : BaseCommandHandler,
        IRequestHandler<AddCalendarEventCommand, CommandResult<CalendarEvent>>,
        IRequestHandler<UpdateCalendarEventCommand, CommandResult<CalendarEvent>>,
        IRequestHandler<DeleteCalendarEventCommand, CommandResult<bool>>
    {

        private readonly ICalendarEventRepository _calendarEventRepository;
        public CalendarEventCommandHandler(
            IUnitOfWork unitOfWork, 
            IMediatorHandler mediatorHandler, 
            INotificator notificator,
            ICalendarEventRepository calendarEventRepository) : base(unitOfWork, mediatorHandler, notificator)
        {
            _calendarEventRepository = calendarEventRepository;
        }

        public async Task<CommandResult<CalendarEvent>> Handle(AddCalendarEventCommand request, CancellationToken cancellationToken)
        {
            var result = new CommandResult<CalendarEvent>();

            if (!ValidateCommand(request))
            {
                return result;
            }

            var entity = await _calendarEventRepository.AddNewAsync(new CalendarEvent(request.Title, request.Description, request.Location, request.StartDate, request.EndDate, request.Email));

            if(!(await Commit())) 
            {
                return result;
            }

            result.Success = true;
            result.Data = entity;

            if(!string.IsNullOrEmpty(request.Email))
            {
                await _mediator.PublishEvent(new CalendarEventCreatedNotification(request.Title, request.Description, request.Location, request.StartDate, request.EndDate, request.Email));
            }

            return result;
        }

        public async Task<CommandResult<CalendarEvent>> Handle(UpdateCalendarEventCommand request, CancellationToken cancellationToken)
        {
            var result = new CommandResult<CalendarEvent>();

            if (!ValidateCommand(request))
            {
                return result;
            }

            var entity = await _calendarEventRepository.GetByIdTrackingAsync(request.Id);

            if (entity == null)
            {
                _notificator.AddError("A calendar event could not be found");
                return result;
            }

            var eventUpdatedNotificaiton = new CalendarEventUpdatedNotification(entity.Title, entity.Description, entity.Location, entity.StartDate, entity.EndDate, request.Email);

            entity.Update(request.Title, request.Description, request.Location, request.StartDate, request.EndDate, request.Email);

            if (!(await Commit()))
            {
                return result;
            }

            result.Success = true;
            result.Data = entity;

            if(!string.IsNullOrEmpty(request.Email))
            {
                eventUpdatedNotificaiton.StartDate = request.StartDate;
                eventUpdatedNotificaiton.EndDate = request.EndDate;
                eventUpdatedNotificaiton.Title = request.Title;
                eventUpdatedNotificaiton.Description = request.Description;
                eventUpdatedNotificaiton.Location = request.Location;

                await _mediator.PublishEvent(eventUpdatedNotificaiton);
            }

            return result;
        }

        public async Task<CommandResult<bool>> Handle(DeleteCalendarEventCommand request, CancellationToken cancellationToken)
        {
            var result = new CommandResult<bool>();

            if (!ValidateCommand(request))
            {
                return result;
            }

            var entity = await _calendarEventRepository.GetByIdTrackingAsync(request.Id);

            if (entity == null)
            {
                _notificator.AddError("A calendar event could not be found");
                return result;
            }

            var deletedEventNotification = new CalendarEventDeletedNotification
            {
                Email = entity.Email,
                Title = entity.Title,
                Location = entity.Location,
                StartDate = entity.StartDate,
            };

            _calendarEventRepository.Delete(entity);

            if (!(await Commit()))
            {
                return result;
            }

            result.Success = true;
            result.Data = true;

            if (!string.IsNullOrEmpty(deletedEventNotification.Email))
            {
                await _mediator.PublishEvent(deletedEventNotification);
            }

            return result;
        }
    }
}

using MediatR;
using Think.Calendar.Domain.Mediator.Interfaces;
using Think.Calendar.Domain.Mediator.Messages;
using Think.Calendar.Domain.Mediator.Model;

namespace Think.Calendar.Infrastructure.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task PublishEventAsync<T>(T @event) where T : MediatorEvent => await _mediator.Publish(@event);
        public async Task<CommandResult<TResult>> SendCommandAsync<TCommand, TResult>(TCommand command) where TCommand : Command<TResult> => await _mediator.Send(command);
    }
}

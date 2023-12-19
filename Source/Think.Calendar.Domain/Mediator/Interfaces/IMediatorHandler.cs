using Think.Calendar.Domain.Mediator.Messages;
using Think.Calendar.Domain.Mediator.Model;

namespace Think.Calendar.Domain.Mediator.Interfaces
{
    public interface IMediatorHandler
    {
        Task<CommandResult<TResult>> SendCommand<TCommand, TResult>(TCommand command) where TCommand : Command<TResult>;

        Task PublishEvent<T>(T @event) where T : MediatorEvent; 
    }
}

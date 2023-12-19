using Think.Calendar.Domain.Mediator.Messages;
using Think.Calendar.Domain.Mediator.Model;

namespace Think.Calendar.Domain.Mediator.Interfaces
{
    public interface IMediatorHandler
    {
        Task<CommandResult<TResult>> SendCommandAsync<TCommand, TResult>(TCommand command) where TCommand : Command<TResult>;

        Task PublishEventAsync<T>(T @event) where T : MediatorEvent; 
    }
}

using FluentValidation.Results;
using MediatR;
using Think.Calendar.Domain.Mediator.Model;

namespace Think.Calendar.Domain.Mediator.Messages
{
    public class Command<TData> : Message, IRequest<CommandResult<TData>>
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public virtual bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}

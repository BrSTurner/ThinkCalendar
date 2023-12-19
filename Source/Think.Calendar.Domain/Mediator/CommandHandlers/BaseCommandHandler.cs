using FluentValidation.Results;
using Think.Calendar.Domain.Mediator.Interfaces;
using Think.Calendar.Domain.Mediator.Messages;
using Think.Calendar.Domain.Notificator.Interfaces;
using Think.Calendar.Domain.UnitOfWork;

namespace Think.Calendar.Domain.Mediator.CommandHandlers
{
    public abstract class BaseCommandHandler
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMediatorHandler _mediator;
        protected readonly INotificator _notificator;

        public BaseCommandHandler(IUnitOfWork unitOfWork,
            IMediatorHandler mediatorHandler,
            INotificator notificator)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediatorHandler;
            _notificator = notificator;
        }

        protected bool ValidateCommand<T>(Command<T> command)
        {
            if (command == null)
            {
                _notificator.AddError($"All fields must be valid in order to perform this operation");
                return false;
            }
            else if (!command.IsValid())
            {
                NotifyValidationResultErrorMessages(command.ValidationResult);
                return false;
            }

            return command.ValidationResult.IsValid;
        }

        protected void NotifyValidationResultErrorMessages(ValidationResult validationResult)
        {
            validationResult.Errors.ForEach(error =>
            {
                _notificator.AddError(error.ErrorMessage);
            });
        }

        protected async Task<bool> CommitAsync()
        {
            if(!(await _unitOfWork.CommitAsync()))
            {
                _notificator.AddError("Sometring went wrong saving data to the database, try again later");
                return false;
            }

            return true;
        }
    }
}

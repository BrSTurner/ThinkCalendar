using Think.Calendar.Domain.Mediator.CommandValidations;
using Think.Calendar.Domain.Mediator.Messages;

namespace Think.Calendar.Domain.Mediator.Commands
{
    public class DeleteCalendarEventCommand : Command<bool>
    {
        public int Id { get; set; }
        public override bool IsValid()
        {
            ValidationResult = new DeleteCalendarEventValidatrion().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

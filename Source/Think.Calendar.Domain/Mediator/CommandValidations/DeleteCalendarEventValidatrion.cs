using FluentValidation;
using Think.Calendar.Domain.Mediator.Commands;

namespace Think.Calendar.Domain.Mediator.CommandValidations
{
    public class DeleteCalendarEventValidatrion : AbstractValidator<DeleteCalendarEventCommand>
    {
        public DeleteCalendarEventValidatrion()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Calendar event identificator must be valid");

            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Calendar event identificator must be valid");
        }
    }
}

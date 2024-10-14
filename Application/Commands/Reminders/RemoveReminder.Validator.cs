using FluentValidation;

namespace Application.Commands.Reminders
{
    public class RemoveReminderValidator : AbstractValidator<RemoveReminder>
    {
        public RemoveReminderValidator()
        {
            RuleFor(command => command.Payload.UserId)
                 .NotEmpty();
            RuleFor(command => command.Payload.ReminderId)
                 .NotEmpty();
        }
    }
}

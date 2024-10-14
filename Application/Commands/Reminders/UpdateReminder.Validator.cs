using FluentValidation;

namespace Application.Commands.Reminders
{
    public class UpdateReminderValidator : AbstractValidator<UpdateReminder>
    {
        public UpdateReminderValidator()
        {
            RuleFor(command => command.Payload.UserId)
                 .NotEmpty();
            RuleFor(command => command.Payload.ReminderId)
                 .NotEmpty();
            RuleFor(command => command.Payload.Channel)
                .NotEmpty()
                .IsInEnum();
            RuleFor(command => command.Payload.Message)
                .NotEmpty()
                .MaximumLength(250);
            RuleFor(command => command.Payload.NotifyAt)
                .NotEmpty()
                .GreaterThanOrEqualTo(DateTime.UtcNow);
        }
    }
}

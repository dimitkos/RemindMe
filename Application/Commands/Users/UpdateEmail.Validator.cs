using FluentValidation;

namespace Application.Commands.Users
{
    public class UpdateEmailValidator : AbstractValidator<UpdateEmail>
    {
        public UpdateEmailValidator()
        {
            RuleFor(command => command.Payload.Email)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(50);
            RuleFor(command => command.Payload.UserId)
                .NotEmpty();
        }
    }
}

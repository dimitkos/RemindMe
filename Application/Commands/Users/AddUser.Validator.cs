using FluentValidation;

namespace Application.Commands.Users
{
    public class AddUserValidator : AbstractValidator<AddUser>
    {
        public AddUserValidator()
        {
            RuleFor(command => command.Payload.Firstname)
                 .NotEmpty()
                 .MaximumLength(30);
            RuleFor(command => command.Payload.Lastname)
                .NotEmpty()
                .MaximumLength(30);
            RuleFor(command => command.Payload.Email)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(50);
            RuleFor(command => command.Payload.Mobile)
                .NotEmpty()
                .MinimumLength(10)
                .MaximumLength(20);
        }
    }
}

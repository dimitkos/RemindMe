using MediatR;

namespace Application.Commands.Reminders
{
    class AddReminderHandler : IRequestHandler<AddReminder, Unit>
    {
        public Task<Unit> Handle(AddReminder request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

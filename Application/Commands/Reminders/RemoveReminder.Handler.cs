using MediatR;

namespace Application.Commands.Reminders
{
    class RemoveReminderHandler : IRequestHandler<RemoveReminder, Unit>
    {
        public Task<Unit> Handle(RemoveReminder request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

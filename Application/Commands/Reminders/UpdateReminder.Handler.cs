using MediatR;

namespace Application.Commands.Reminders
{
    class UpdateReminderHandler : IRequestHandler<UpdateReminder, Unit>
    {
        public Task<Unit> Handle(UpdateReminder request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

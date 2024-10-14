using MediatR;
using Shared;

namespace Application.Commands.Reminders
{
    public class RemoveReminder : IRequest<Unit>
    {
        public RemoveReminderPayload Payload { get; }

        public RemoveReminder(RemoveReminderPayload payload)
        {
            Payload = payload;
        }
    }
}

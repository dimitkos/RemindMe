using MediatR;
using Shared;

namespace Application.Commands.Reminders
{
    public class UpdateReminder : IRequest<Unit>
    {
        public UpdateReminderPayload Payload { get; }

        public UpdateReminder(UpdateReminderPayload payload)
        {
            Payload = payload;
        }
    }
}

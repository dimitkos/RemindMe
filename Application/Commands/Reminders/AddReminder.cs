using MediatR;
using Shared;

namespace Application.Commands.Reminders
{
    public class AddReminder : IRequest<Unit>
    {
        public AddReminderPayload Payload { get; }

        public AddReminder(AddReminderPayload payload)
        {
            Payload = payload;
        }
    }
}

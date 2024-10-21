using Application.Services.Infrastructure.Reminders;
using Domain.Aggregates;
using IdGen;
using MediatR;

namespace Application.Commands.Reminders
{
    class AddReminderHandler : IRequestHandler<AddReminder, Unit>
    {
        private readonly IReminderCommandRepository _reminderRepository;
        private readonly IdGenerator _idGenerator;

        public AddReminderHandler(IReminderCommandRepository reminderRepository, IdGenerator idGenerator)
        {
            _reminderRepository = reminderRepository;
            _idGenerator = idGenerator;
        }

        public async Task<Unit> Handle(AddReminder request, CancellationToken cancellationToken)
        {
            var user = Reminder.Create(
                id: _idGenerator.CreateId(),
                message: request.Payload.Message,
                channel: request.Payload.Channel,
                notifyAt: request.Payload.NotifyAt,
                userId: request.Payload.UserId);

            await _reminderRepository.Create(user);

            return Unit.Value;
        }
    }
}

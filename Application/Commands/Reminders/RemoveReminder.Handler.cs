using Application.Services.Infrastructure.Reminders;
using Application.Services.Infrastructure;
using Domain.Aggregates;
using MediatR;

namespace Application.Commands.Reminders
{
    class RemoveReminderHandler : IRequestHandler<RemoveReminder, Unit>
    {
        private readonly IReminderCommandRepository _reminderRepository;
        private readonly IDomainRetrievalRepository<long, Reminder> _reminderRetrieval;

        public RemoveReminderHandler(IReminderCommandRepository reminderRepository, IDomainRetrievalRepository<long, Reminder> reminderRetrieval)
        {
            _reminderRepository = reminderRepository;
            _reminderRetrieval = reminderRetrieval;
        }

        public async Task<Unit> Handle(RemoveReminder request, CancellationToken cancellationToken)
        {
            var reminder = await _reminderRetrieval.TryGet(request.Payload.ReminderId);

            if (reminder is null)
                throw new Exception($"Reminder with id: {request.Payload.ReminderId} not found");

            await _reminderRepository.RemoveReminder(reminder);

            return Unit.Value;
        }
    }
}

using Application.Services.Infrastructure;
using Application.Services.Infrastructure.Reminders;
using Domain.Aggregates;
using MediatR;

namespace Application.Commands.Reminders
{
    class UpdateReminderHandler : IRequestHandler<UpdateReminder, Unit>
    {
        private readonly IReminderCommandRepository _reminderRepository;
        private readonly IDomainRetrievalRepository<long, Reminder> _reminderRetrieval;

        public UpdateReminderHandler(IReminderCommandRepository reminderRepository, IDomainRetrievalRepository<long, Reminder> reminderRetrieval)
        {
            _reminderRepository = reminderRepository;
            _reminderRetrieval = reminderRetrieval;
        }

        public async Task<Unit> Handle(UpdateReminder request, CancellationToken cancellationToken)
        {
            var reminder = await _reminderRetrieval.TryGet(request.Payload.ReminderId);

            if (reminder is null)
                throw new Exception($"Reminder with id: {request.Payload.ReminderId} not found");

            await _reminderRepository.UpdateReminder(reminder);

            return Unit.Value;
        }
    }
}

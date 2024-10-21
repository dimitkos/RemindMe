using Domain.Aggregates;

namespace Application.Services.Infrastructure.Reminders
{
    public interface IReminderCommandRepository
    {
        Task Create(Reminder reminder);
        Task UpdateReminder(Reminder reminder);
        Task RemoveReminder(Reminder reminder);
    }
}

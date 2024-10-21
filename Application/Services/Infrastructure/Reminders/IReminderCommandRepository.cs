using Domain.Aggregates;

namespace Application.Services.Infrastructure.Reminders
{
    public interface IReminderCommandRepository
    {
        Task Create(Reminder user);
        Task UpdateReminder(Reminder user);
        Task RemoveReminder(Reminder user);
    }
}

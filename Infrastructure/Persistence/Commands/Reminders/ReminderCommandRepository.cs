using Application.Services.Infrastructure.Reminders;
using Domain.Aggregates;
using Infrastructure.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Commands.Reminders
{
    class ReminderCommandRepository : IReminderCommandRepository
    {
        private readonly DbContextOptions<RemindMeDbContext> _options;

        public ReminderCommandRepository(DbContextOptions<RemindMeDbContext> options)
        {
            _options = options;
        }

        public async Task Create(Reminder reminder)
        {
            using var context = new RemindMeDbContext(_options);

            context.Reminders.Add(reminder);
            await context.SaveChangesAsync();
        }

        public async Task UpdateReminder(Reminder reminder)
        {
            using var context = new RemindMeDbContext(_options);

            var userEntry = context.Entry(reminder);
            userEntry.Property(x => x.Message).IsModified = true;
            userEntry.Property(x => x.Channel).IsModified = true;
            userEntry.Property(x => x.NotifyAt).IsModified = true;

            await context.SaveChangesAsync();
        }

        public async Task RemoveReminder(Reminder reminder)
        {
            using var context = new RemindMeDbContext(_options);

            context.Reminders.Remove(reminder);
            await context.SaveChangesAsync();
        }
    }
}

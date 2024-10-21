using Application.Services.Infrastructure;
using Domain.Aggregates;
using Infrastructure.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Queries.Reminders
{
    class ReminderRetrievalRepository : IDomainRetrievalRepository<long, Reminder>
    {
        private readonly DbContextOptions<RemindMeDbContext> _options;

        public ReminderRetrievalRepository(DbContextOptions<RemindMeDbContext> options)
        {
            _options = options;
        }

        public async Task<Reminder?> TryGet(long id)
        {
            using var context = new RemindMeDbContext(_options);

            var reminder = await context.Reminders.FirstOrDefaultAsync(x => x.Id == id);

            return reminder;
        }

        public async Task<Dictionary<long, Reminder>> TryGetMany(long[] ids)
        {
            using var context = new RemindMeDbContext(_options);

            var reminders = await context.Reminders
                .Where(x => ids.Contains(x.Id))
                .ToDictionaryAsync(x => x.Id);

            return reminders;
        }
    }
}

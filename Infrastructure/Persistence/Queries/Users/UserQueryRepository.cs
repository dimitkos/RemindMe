using Application.Services.Infrastructure.Users;
using Infrastructure.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace Infrastructure.Persistence.Queries.Users
{
    public class UserQueryRepository : IUserQueryRepository
    {
        private readonly DbContextOptions<RemindMeDbContext> _options;

        public UserQueryRepository(DbContextOptions<RemindMeDbContext> options)
        {
            _options = options;
        }

        public async Task<User[]> GetUsers(long[] ids)
        {
            using var context = new RemindMeDbContext(_options);

            var users = await context.Users
                .Where(x => ids.Contains(x.Id))
                .ToArrayAsync();

            return users
                .Select(user => new User(
                    id: user.Id,
                    firstname: user.Firstname,
                    lastname: user.Lastname,
                    email: user.Email,
                    mobile: user.Mobile,
                    registeredAt: user.RegisteredAt,
                    reminders: user.Reminders
                    .Select(r => new Reminder(
                        id: r.Id,
                        message: r.Message,
                        channel: r.Channel,
                        createdAt: r.CreatedAt,
                        notifyAt: r.NotifyAt
                        ))
                    .ToList()))
               .ToArray();
        }
    }
}

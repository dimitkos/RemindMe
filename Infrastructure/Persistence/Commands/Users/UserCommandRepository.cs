using Application.Services.Infrastructure.Users;
using Domain.Aggregates;
using Infrastructure.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Commands.Users
{
    class UserCommandRepository : IUserCommandRepository
    {
        private readonly DbContextOptions<RemindMeDbContext> _options;

        public UserCommandRepository(DbContextOptions<RemindMeDbContext> options)
        {
            _options = options;
        }

        public async Task Create(User user)
        {
            using var context = new RemindMeDbContext(_options);

            context.Users.Add(user);
            await context.SaveChangesAsync();
        }

        public async Task UpdateEmail(User user)
        {
            using var context = new RemindMeDbContext(_options);

            var userEntry = context.Entry(user);
            userEntry.Property(x => x.Email).IsModified = true;

            await context.SaveChangesAsync();
        }
    }
}

using Application.Services.Infrastructure;
using Domain.Aggregates;
using Infrastructure.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Queries.Users
{
    class UserRetrievalRepository : IDomainRetrievalRepository<long, User>
    {
        private readonly DbContextOptions<RemindMeDbContext> _options;

        public UserRetrievalRepository(DbContextOptions<RemindMeDbContext> options)
        {
            _options = options;
        }

        public Task<User?> TryGet(long id)
        {
            using var context = new RemindMeDbContext(_options);

            var user = context.Users.FirstOrDefaultAsync(x => x.Id == id);

            return user;
        }

        public Task<Dictionary<long, User>> TryGetMany(long[] ids)
        {
            using var context = new RemindMeDbContext(_options);

            var users = context.Users
                .Where(x => ids.Contains(x.Id))
                .ToDictionaryAsync(x => x.Id);

            return users;
        }
    }
}

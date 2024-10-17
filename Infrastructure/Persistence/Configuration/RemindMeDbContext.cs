using Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Persistence.Configuration
{
    public class RemindMeDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Reminder> Reminders { get; set; }

        public RemindMeDbContext(DbContextOptions<RemindMeDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}

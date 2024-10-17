using Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    class ReminderConfiguration : IEntityTypeConfiguration<Reminder>
    {
        public void Configure(EntityTypeBuilder<Reminder> builder)
        {
            builder.ToTable("Reminders");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedNever().IsRequired();
            builder.Property(x => x.Message).HasMaxLength(250).IsRequired();
            builder.Property(x => x.Channel).IsRequired();
            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.NotifyAt).IsRequired();
        }
    }
}

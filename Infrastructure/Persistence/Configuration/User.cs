using Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedNever().IsRequired();
            builder.Property(x => x.Firstname).HasMaxLength(30).IsRequired();
            builder.Property(x => x.Lastname).HasMaxLength(30).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Mobile).HasMaxLength(20).IsRequired();

            builder
                .HasMany(user => user.Reminders)
                .WithOne()
                .HasForeignKey(reminder => reminder.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

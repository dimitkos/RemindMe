using Domain.Aggregates;

namespace Application.Services.Infrastructure.Users
{
    public interface IUserCommandRepository
    {
        Task Create(User user);
        Task UpdateEmail(User user);
    }
}

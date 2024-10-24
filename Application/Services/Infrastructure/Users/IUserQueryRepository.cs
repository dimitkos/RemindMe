using Shared;

namespace Application.Services.Infrastructure.Users
{
    public interface IUserQueryRepository
    {
        //Task<User?> SarchUsers();
        Task<User[]> GetUsers(long[] ids);

    }
}

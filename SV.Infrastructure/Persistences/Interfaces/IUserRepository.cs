using SV.Domain.Entities;
using SV.Utilities.Dtos.User;

namespace SV.Infrastructure.Persistences.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> GetUserByUserNameAsync(string userName);

        Task<bool> LoginSucceeded(UserDto userDto);
    }
}

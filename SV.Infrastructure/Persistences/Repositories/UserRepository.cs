using Microsoft.EntityFrameworkCore;
using SV.Domain.Entities;
using SV.Infrastructure.Persistences.Contexts;
using SV.Infrastructure.Persistences.Interfaces;
using SV.Utilities.Dtos.User;

namespace SV.Infrastructure.Persistences.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly SVContext _context;

        public UserRepository(SVContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<User?> GetUserByUserNameAsync(string userName)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName.Equals(userName));
        }

        public async Task<int> LoginSucceeded(UserDto userDto)
        {
            var user = await GetUserByUserNameAsync(userDto.UserName);

            if (user != null)
            {
                if (user.Password == userDto.Password)
                {
                    return user.Id;
                }
            }

            return 0;
        }

        public async Task<bool> VerifyPassword(int userId, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id.Equals(userId));

            if (user != null)
            {
                if (user.Password == password)
                {
                    return true;
                }
            }

            return false;
        }
    }
}

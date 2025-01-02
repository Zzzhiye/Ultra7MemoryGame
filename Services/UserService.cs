using MemoryGame.Models;
using Microsoft.EntityFrameworkCore;
using MemoryGame.Data; 

namespace MemoryGame.Services
{
    public class UserService : IUserService
    {
        private readonly MemoryGameContext _context;

        public UserService(MemoryGameContext context)
        {
            _context = context;
        }

        public async Task<User?> ValidateUserAsync(string username, string password)
        {
            var user = await _context.User
        .FirstOrDefaultAsync(u => u.UserName == username);

            if (user != null && user.Password == password)
            {
                return user;
            }

            return null;
        }

        public async Task<User> GetUserByIdAsync(long userId)
        {
            return await _context.User.FindAsync(userId);
        }

        public async Task<bool> UpdateUserAsync(long userId, UpdateUserDto updateUserDto)
        {
            var user = await _context.User.FindAsync(userId);

            if (user == null)
            {
                return false;
            }

            user.UserName = updateUserDto.UserName;
            user.Email = updateUserDto.Email;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}

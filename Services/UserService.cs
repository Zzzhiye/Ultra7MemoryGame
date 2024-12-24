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
            return await _context.User
                .FirstOrDefaultAsync(u => u.UserName == username && u.Password == password);
        }
    }
}

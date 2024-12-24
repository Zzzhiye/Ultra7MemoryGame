using MemoryGame.Models;

namespace MemoryGame.Services
{
    public interface IUserService
    {
        Task<User?> ValidateUserAsync(string username, string password);
    }
}

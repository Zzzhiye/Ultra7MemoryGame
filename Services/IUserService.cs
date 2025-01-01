using MemoryGame.Models;

namespace MemoryGame.Services
{
    public interface IUserService
    {
        Task<User?> ValidateUserAsync(string username, string password);
        Task<User> GetUserByIdAsync(long userId);
        Task<bool> UpdateUserAsync(long userId, UpdateUserDto updateUserDto);
    }
}

using TaskManagementAPI.Models;

namespace TaskManagementAPI.Repositories;

public interface IUserRepository
{
    Task<User?> AuthenticateAsync(string username, string password);
    Task<User> RegisterAsync(User user);
}
using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Data;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User?> AuthenticateAsync(string username, string password)
    {
        // Note: In a production app, passwords should be hashed, not stored as plain text.
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
    }
    public async Task<User> RegisterAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }
}
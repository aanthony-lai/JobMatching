using JobMatching.Application.UserManagement.Interfaces;
using JobMatching.DataAccess.Context;
using JobMatching.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobMatching.DataAccess.Repositories;

public class UserRepository: IUserRepository
{
    private readonly AppDbContext _appDbContext;

    public UserRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    
    public async Task<User?> GetUserByIdAsync(Guid userId)
    {
        return await _appDbContext.Users.FirstOrDefaultAsync(u => u.UserId == userId);
    }

    public async Task<IEnumerable<User>> GetUsersAsync()
    {
        return await _appDbContext.Users.ToListAsync();
    }
}
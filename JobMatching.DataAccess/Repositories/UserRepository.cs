using JobMatching.Application.Interfaces;
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
    
    public async Task<User?> GetUserByIdAsync(Guid userId, bool withTracking = true)
    {
        return await _appDbContext.Users
            .Include(u => u.Competences)
            .Include(u => u.Applications)
                .ThenInclude(a => a.Job)
            .FirstOrDefaultAsync(u => u.UserId == userId);
    }

    public async Task<List<User>> GetUsersAsync(bool withTracking = true)
    {
        return await _appDbContext.Users
			.Include(u => u.Competences)
			.Include(u => u.Applications)
			    .ThenInclude(a => a.Job)
			.ToListAsync();
    }

    public async Task UpdateUserAsync(User user)
    {
		try
		{
			_appDbContext.Users.Update(user);
			await _appDbContext.SaveChangesAsync();
		}
		catch (Exception)
		{
			throw new InvalidOperationException("An error occured while trying to save the changes.");
		}
	}
}
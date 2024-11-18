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
		var query = _appDbContext.Users.AsQueryable();

		if (!withTracking)
			query = query.AsNoTracking();

        return await query
            .Include(u => u.Competences)
            .Include(u => u.Applications)
            .ThenInclude(a => a.Job)
            .FirstOrDefaultAsync(u => u.UserId == userId) ?? null;
    }

    public async Task<List<User>> GetUsersAsync(bool withTracking = true)
    {
        var query = _appDbContext.Users.AsQueryable();

        if (!withTracking)
			query = query.AsNoTracking();

        return await query
			.Include(u => u.Competences)
			.Include(u => u.Applications)
			.ThenInclude(a => a.Job)
			.ToListAsync();
    }
}
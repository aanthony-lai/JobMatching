using JobMatching.Application.Interfaces;
using JobMatching.DataAccess.Context;
using JobMatching.DataAccess.QueryExtensions;
using JobMatching.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobMatching.DataAccess.Repositories
{
    public class EmployerRepository : IEmployerRepository
	{
		private readonly AppDbContext _appDbContext;

		public EmployerRepository(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}

		public async Task<Employer?> GetEmployerByIdAsync(Guid employerId, bool withTracking = true)
		{
			return await _appDbContext.Employers
				.AddTracking(withTracking)
				.Include(emp => emp.Jobs)
					.ThenInclude(job => job.Competences)
				.FirstOrDefaultAsync(emp => emp.EmployerId == employerId); 
		}

		public async Task<List<Employer>> GetEmployersAsync(bool withTracking = true)
		{
			return await _appDbContext.Employers
				.AddTracking(withTracking)
				.Include(emp => emp.Jobs)
				.ThenInclude(job => job.Competences)
				.ToListAsync();
		}
	}
}

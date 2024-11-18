using JobMatching.Application.Interfaces;
using JobMatching.DataAccess.Context;
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
			var query = _appDbContext.Employers.AsQueryable();

			if (!withTracking)
				query = query.AsNoTracking();

			return await query
				.Include(emp => emp.Jobs)
				.ThenInclude(job => job.Competences)
				.FirstOrDefaultAsync(emp => emp.EmployerId == employerId) 
				?? null;
		}

		public async Task<List<Employer>> GetEmployersAsync(bool withTracking = true)
		{
			var query = _appDbContext.Employers.AsQueryable();

			if (!withTracking)
				query = query.AsNoTracking();

			return await query
				.Include(emp => emp.Jobs)
				.ThenInclude(job => job.Competences)
				.ToListAsync();
		}
	}
}

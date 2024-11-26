using JobMatching.Application.Interfaces;
using JobMatching.DataAccess.Context;
using JobMatching.DataAccess.QueryExtensions;
using JobMatching.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobMatching.DataAccess.Repositories
{
    public class JobRepository : IJobRepository
	{
		private readonly AppDbContext _appDbContext;

		public JobRepository(AppDbContext appDbContext) 
		{
			_appDbContext = appDbContext;
		}
	
		public async Task<Job?> GetJobByIdAsync(Guid jobId, bool withTracking)
		{
			return await _appDbContext.Jobs
				.AddTracking(withTracking)
					.Include(j => j.Employer)
					.Include(j => j.Competences)
				.FirstOrDefaultAsync(j => j.JobId == jobId);
		}

		public async Task<List<Job>> GetJobsAsync(bool withTracking)
		{
			return await _appDbContext.Jobs
				.AddTracking(withTracking)
					.Include(j => j.Employer)
					.Include(j => j.Competences)
				.ToListAsync();
		}
	}
}

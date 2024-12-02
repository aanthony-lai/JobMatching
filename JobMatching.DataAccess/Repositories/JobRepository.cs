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
	
		public async Task<Job?> GetJobByIdAsync(Guid jobId, bool withTracking = false)
		{
			return await _appDbContext.Jobs
				.AddTracking(withTracking)
					.Include(j => j.Employer)
					.Include(j => j.JobCompetences)
						.ThenInclude(jc => jc.Competence)
				.FirstOrDefaultAsync(j => j.Id == jobId);
		}

		public async Task<List<Job>> GetJobsAsync(bool withTracking = false)
		{
			return await _appDbContext.Jobs
				.AddTracking(withTracking)
					.Include(j => j.Employer)
					.Include(j => j.JobCompetences)
						.ThenInclude(jc => jc.Competence)
				.ToListAsync();
		}

		public async Task<bool> JobExistsAsync(Guid jobId)
		{
			return await _appDbContext.Jobs.AnyAsync(j => j.Id == jobId);
		}
	}
}

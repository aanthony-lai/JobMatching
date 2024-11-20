using JobMatching.Application.Interfaces;
using JobMatching.DataAccess.Context;
using JobMatching.DataAccess.QueryExtensions;
using JobMatching.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobMatching.DataAccess.Repositories
{
	public class JobApplicationRepository : IJobApplicationRepository
	{
		private readonly AppDbContext _appDbContext;

		public JobApplicationRepository(AppDbContext appDbContext) 
		{
			_appDbContext = appDbContext;
		}

		public async Task<JobApplication?> GetJobApplicationByIdAsync(Guid jobApplicationId, bool withTracking = true)
		{
			return await _appDbContext.Applications
				.AddTracking(withTracking)
				.Include(a => a.User)
				.Include(a => a.Job)
				.FirstOrDefaultAsync(a => a.JobApplicationId == jobApplicationId);
		}

		public async Task<List<JobApplication>> GetJobApplicationsAsync(bool withTracking = true)
		{
			return await _appDbContext.Applications
				.AddTracking(withTracking)
				.Include(a => a.User)
				.Include(a => a.Job)
				.ToListAsync();
		}
	}
}

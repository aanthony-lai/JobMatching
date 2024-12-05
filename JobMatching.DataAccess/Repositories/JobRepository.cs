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

		public async Task<Job?> GetJobByIdAsync(Guid jobId, bool withTracking = true)
		{
			return await _appDbContext.Jobs
				.AddTracking(withTracking)
					.Include(j => j.Employer)
					.Include(j => j.JobCompetences)
					.ThenInclude(jc => jc.Competence)
				.FirstOrDefaultAsync(j => j.Id == jobId);
		}

		public async Task<List<Job>> GetJobsByEmployerIdAsync(Guid employerId, bool withTracking = true)
		{
			return await _appDbContext.Jobs
				.AddTracking(withTracking)
				.Where(j => j.EmployerId == employerId)
					.Include(j => j.Employer)
					.Include(j => j.JobCompetences)
					.ThenInclude(jc => jc.Competence)
				.ToListAsync();
		}

		public async Task<List<Job>> GetJobsAsync(bool withTracking = true)
		{
			return await _appDbContext.Jobs
				.AddTracking(withTracking)
					.Include(j => j.Employer)
					.Include(j => j.JobCompetences)
					.ThenInclude(jc => jc.Competence)
				.ToListAsync();
		}

		public async Task AddJobAsync(Job job)
		{
			await _appDbContext.Jobs.AddAsync(job);
			await _appDbContext.SaveChangesAsync();
		}

		public async Task UpdateJobAsync(Job job)
		{
			job.MetaData.SetUpdatedAt();
			_appDbContext.Jobs.Update(job);
			await _appDbContext.SaveChangesAsync();
		}

		public async Task<bool> JobExistsAsync(Guid jobId)
		{
			return await _appDbContext.Jobs.AnyAsync(j => j.Id == jobId);
		}
	}
}

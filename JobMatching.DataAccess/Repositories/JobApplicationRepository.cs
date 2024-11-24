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

		public async Task<List<JobApplication>> GetJobApplicationsByCandidateIdAsync(Guid candidateId, bool withTracking = true)
		{
			return await _appDbContext.Applications
				.AddTracking(withTracking)
				.Include(a => a.Candidate)
					.ThenInclude(c => c.Competences)
				.Include(a => a.Job)
					.ThenInclude(j => j.Competences)
				.Where(a => a.CandidateId == candidateId).ToListAsync();
		}

		public async Task<List<JobApplication>> GetJobApplicationsAsync(bool withTracking = true)
		{
			return await _appDbContext.Applications
				.AddTracking(withTracking)
				.Include(a => a.Candidate)
					.ThenInclude(c => c.Competences)
				.Include(a => a.Job)
					.ThenInclude(j => j.Competences)
				.ToListAsync();
		}
	}
}

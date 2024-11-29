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
				.Where(a => a.CandidateId == candidateId)
				.Include(a => a.Candidate)
					.ThenInclude(c => c.Competences)
				.Include(a => a.Job)
					.ThenInclude(j => j.JobCompetences)
					.ThenInclude(jc => jc.Competence)
				.ToListAsync();
		}

		//Should maybe be moved to an individual class?
		public async Task<List<JobApplication>> GetJobApplicationsByJobIdAsync(Guid jobId, bool withTracking = true)
		{
			return await _appDbContext.Applications
				.AddTracking(withTracking)
				.Where(a => a.JobId == jobId)
				.Include(a => a.Candidate)
					.ThenInclude(c => c.Competences)
				.Include(a => a.Job)
					.ThenInclude(j => j.JobCompetences)
					.ThenInclude(jc => jc.Competence)
				.ToListAsync();
		}

		//Should be removed later
		public async Task<List<JobApplication>> GetJobApplicationsAsync(bool withTracking = true)
		{
			return await _appDbContext.Applications
				.AddTracking(withTracking)
				.Include(a => a.Candidate)
					.ThenInclude(c => c.Competences)
				.Include(a => a.Job)
					.ThenInclude(j => j.JobCompetences)
					.ThenInclude(jc => jc.Competence)
				.ToListAsync();
		}
	}
}

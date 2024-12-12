using JobMatching.DataAccess.Context;
using JobMatching.DataAccess.QueryExtensions;
using JobMatching.Domain.Entities;
using JobMatching.Domain.Entities.JunctionEntities;
using JobMatching.Domain.Repositories;
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

        public async Task<Job?> GetByIdAsync(Guid jobId, bool withTracking = true)
        {
            return await _appDbContext.Jobs
                .AddTracking(withTracking)
                    .Include(j => j.Employer)
                    .Include(j => j.JobCompetences)
                    .ThenInclude(jc => jc.Competence)
                .FirstOrDefaultAsync(j => j.Id == jobId);
        }

        public async Task<List<Job>> GetByJobTitleAsync(string jobTitle, bool withTracking = true)
        {
            return await _appDbContext.Jobs
                .AddTracking(withTracking)
                .Where(j => j.Title.Contains(jobTitle))
                    .Include(j => j.Employer)
                    .Include(j => j.JobCompetences)
                    .ThenInclude(jc => jc.Competence)
                .ToListAsync();
        }

        public async Task<List<Job>> GetAllAsync(bool withTracking = true)
        {
            return await _appDbContext.Jobs
                .AddTracking(withTracking)
                    .Include(j => j.Employer)
                    .Include(j => j.JobCompetences)
                    .ThenInclude(jc => jc.Competence)
                .ToListAsync();
        }

        public async Task<Job> AddAsync(Job job)
        {
            await _appDbContext.Jobs.AddAsync(job);
            await _appDbContext.SaveChangesAsync();
            return job;
        }

        public async Task<JobCompetence> AddJobCompetenceAsync(JobCompetence jobCompetence)
        {
            await _appDbContext.JobCompetences.AddAsync(jobCompetence);
            await _appDbContext.SaveChangesAsync();
            return jobCompetence;
        }

        public async Task UpdateJobAsync(Job job)
        {
            job.MetaData.SetUpdatedAt();
            _appDbContext.Jobs.Update(job);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(Guid jobId)
        {
            return await _appDbContext.Jobs.AnyAsync(j => j.Id == jobId);
        }
    }
}

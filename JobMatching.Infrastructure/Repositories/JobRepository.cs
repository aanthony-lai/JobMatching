using JobMatching.Domain.Entities.Job;
using JobMatching.Domain.Repositories;
using JobMatching.Infrastructure.DataAccess;
using JobMatching.Infrastructure.QueryExtensions;
using Microsoft.EntityFrameworkCore;

namespace JobMatching.Infrastructure.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly AppDbContext _appDbContext;

        public JobRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Job>> GetAsync(bool withTracking = false)
        {
            return await _appDbContext.Jobs
                .AddTracking(withTracking)
                .Include(j => j.JobCompetences)
                .Include(j => j.Applicants)
                .Include(j => j.JobCompetences)
                .ToListAsync();
        }

        public async Task<Job?> GetByIdAsync(Guid jobId, bool withTracking = false)
        {
            return await _appDbContext.Jobs
                .AddTracking(withTracking)
                .Where(j => j.Id == jobId)
                .Include(j => j.JobCompetences)
                .Include(j => j.Applicants)
                .Include(j => j.JobCompetences)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Job>> GetByNameAsync(string title, bool withTracking = false)
        {
            return await _appDbContext.Jobs
                .AddTracking(withTracking)
                .Where(j => j.JobTitle.Title.Contains(title))
                .Include(j => j.JobCompetences)
                .Include(j => j.Applicants)
                .Include(j => j.JobCompetences)
                .ToListAsync();
        }

        public async Task SaveAsync(Job job)
        {
            await _appDbContext.Jobs.AddAsync(job);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Job job)
        {
            _appDbContext.Jobs.Update(job);
            await _appDbContext.SaveChangesAsync();
        }
    }
}

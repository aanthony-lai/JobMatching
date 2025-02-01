using JobMatching.Domain.Domain.Job.Entities;
using JobMatching.Domain.Repositories;
using JobMatching.Infrastructure.DataAccess;
using JobMatching.Infrastructure.DataAccess.Entities;
using JobMatching.Infrastructure.QueryExtensions;
using Microsoft.EntityFrameworkCore;

namespace JobMatching.Infrastructure.Repositories
{
    public class JobRepository(AppDbContext appDbContext) : IJobRepository
    {
        public async Task<IEnumerable<Job>> GetAsync(bool withTracking = false)
        {
            return await appDbContext.Jobs
                .AddTracking(withTracking)
                .Include(j => j.Employer)
                .Include(j => j.Applications)
                    .ThenInclude(a => a.Candidate)
                .Include(j => j.Competences)
                .Select(j => ToDomain(j))
                .ToListAsync();
        }

        public async Task<Job?> GetByIdAsync(Guid jobId, bool withTracking = false)
        {
            var job = await appDbContext.Jobs
                .Include(j => j.Employer)
                .Include(j => j.Applications)
                .Include(j => j.Competences)
                .FirstOrDefaultAsync(j => j.Id == jobId);
            
            return job != null ? ToDomain(job) : null;
        }

        public async Task<IEnumerable<Job>> GetByNameAsync(string title, bool withTracking = false)
        {
            return await appDbContext.Jobs
                .Include(j => j.Employer)
                .Include(j => j.Applications)
                .Include(j => j.Competences)
                .Where(j => j.Title.Contains(title))
                .Select(j => ToDomain(j))
                .ToListAsync();
        }

        public async Task SaveAsync(Job domainJob)
        {
            var job = ToPersistence(domainJob);
            appDbContext.Jobs.Update(job);
            await SaveAsync();
        }

        public async Task SaveAsync() => await appDbContext.SaveChangesAsync();

        private Job ToDomain(JobEntity job)
        {
            return Job.Load(
                job.Id,
                job.Title,
                job.Description,
                job.MaxSalary,
                job.MinSalary,
                job.EmployerId,
                job.Applications
                    .Select(application => application.Candidate)
                    .Select(candidate => candidate.Id)
                    .ToList(),
                job.Competences.Select(c => Domain.Domain.Job.Entities.JobCompetence
                    .Load(c.CompetenceId, c.Competence.Name, c.IsCritical))
                    .ToList());
        }

        private JobEntity ToPersistence(Job domainJob)
        {
            return new JobEntity()
            {
                Id = domainJob.Id,
                Title = domainJob.JobTitle.Title,
                MaxSalary = domainJob.Salary.MaxSalary,
                MinSalary = domainJob.Salary.MinSalary,
                EmployerId = domainJob.EmployerId,
            };
        }
    }
}

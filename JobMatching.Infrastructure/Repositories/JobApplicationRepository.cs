using JobMatching.Domain.Entities.JobApplication;
using JobMatching.Domain.Repositories;
using JobMatching.Infrastructure.DataAccess;
using JobMatching.Infrastructure.DataAccess.Entities;
using JobMatching.Infrastructure.QueryExtensions;
using Microsoft.EntityFrameworkCore;

namespace JobMatching.Infrastructure.Repositories
{
    public class JobApplicationRepository(AppDbContext appDbContext) : IJobApplicationRepository
    {
        public async Task<ICollection<JobApplication>> GetAsync(Guid candidateId, bool withTracking = false)
        {
            return await appDbContext.JobApplications
                .AddTracking(withTracking)
                .Where(a => a.CandidateId == candidateId)
                    .Include(a => a.Job)
                    .Include(a => a.Candidate)
                .Select(a => ToDomain(a))
                .ToListAsync();
        }

        public async Task SaveAsync(JobApplication domainApplication)
        {
            var application = ToPersistence(domainApplication);
            appDbContext.Update(application);
            await SaveAsync();
        }

        public async Task SaveAsync() => await appDbContext.SaveChangesAsync();

        private JobApplication ToDomain(JobApplicationEntity application)
        {
            return JobApplication.Load(
                application.Id,
                application.CandidateId,
                application.JobId,
                application.Status,
                application.Created);
        }

        private JobApplicationEntity ToPersistence(JobApplication domainApplication)
        {
            return new JobApplicationEntity()
            {
                Id = domainApplication.Id,
                JobId = domainApplication.JobId,
                CandidateId = domainApplication.CandidateId,
                Status = domainApplication.Status
            };
        }
    }
}

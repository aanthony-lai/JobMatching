using JobMatching.Domain.Entities.JobApplication;

namespace JobMatching.Domain.Repositories
{
    public interface IJobApplicationRepository
    {
        Task<IEnumerable<JobApplication>> GetAsync(Guid candidateId, bool isTracking = false);
        Task SaveAsync(JobApplication jobApplication);
        Task SaveAsync();
    }
}

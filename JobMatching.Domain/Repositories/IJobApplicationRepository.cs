using JobMatching.Domain.Entities.JobApplication;

namespace JobMatching.Domain.Repositories
{
    public interface IJobApplicationRepository
    {
        Task<ICollection<JobApplication>> GetAsync(Guid candidateId, bool isTracking = false);
        Task SaveAsync(JobApplication jobApplication);
    }
}

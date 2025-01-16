using JobMatching.Domain.Domain.Job.Entities;

namespace JobMatching.Domain.Repositories;

public interface IJobRepository
{
    Task<List<Job>> GetAsync(bool withTracking = false);
    Task<Job?> GetByIdAsync(Guid jobId, bool withTracking = false);
    Task<List<Job>> GetByNameAsync(string title, bool withTracking = false);
    Task SaveAsync(Job job);
}

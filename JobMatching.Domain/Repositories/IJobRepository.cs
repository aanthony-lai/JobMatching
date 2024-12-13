using JobMatching.Domain.Entities.Job;

namespace JobMatching.Domain.Repositories;

public interface IJobRepository
{
    Task<List<Job>> GetAsync(bool withTracking);
    Task<Job?> GetByIdAsync(bool withTracking);
    Task<Job?> GetByNameAsync(bool withTracking);
    Task<bool> SaveAsync(Job job);
    Task<bool> UpdateAsync(Job job);
}

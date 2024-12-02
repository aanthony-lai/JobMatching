using JobMatching.Domain.Entities;

namespace JobMatching.Application.Interfaces;

public interface IJobRepository
{
	Task<Job?> GetJobByIdAsync(Guid jobId, bool withTracking = true);
	Task<List<Job>> GetJobsByEmployerIdAsync(Guid employerId, bool withTracking = true);
	Task<List<Job>> GetJobsAsync(bool withTracking = true);
	Task SaveJobAsync(Job job);
	Task<bool> JobExistsAsync(Guid jobId);
}

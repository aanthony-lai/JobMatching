using JobMatching.Domain.Entities;

namespace JobMatching.Application.Interfaces;

public interface IJobRepository
{
	Task<List<Job>> GetJobsByEmployerIdAsync(Guid employerId, bool withTracking = true);
	Task<List<Job>> GetJobsAsync(bool withTracking = true);
	Task<bool> JobExistsAsync(Guid jobId);
}

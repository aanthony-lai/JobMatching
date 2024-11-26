using JobMatching.Domain.Entities;

namespace JobMatching.Application.Interfaces;

public interface IJobRepository
{
	Task<Job?> GetJobByIdAsync(Guid jobId, bool withTracking);
	Task<List<Job>> GetJobsAsync(bool withTracking);
}

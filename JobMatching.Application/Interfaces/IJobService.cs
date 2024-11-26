using JobMatching.Application.DTO.Job;

namespace JobMatching.Application.Interfaces;

public interface IJobService
{
	Task<JobDTO?> GetJobByIdAsync(Guid jobId);
	Task<List<JobDTO>> GetJobsAsync();
}

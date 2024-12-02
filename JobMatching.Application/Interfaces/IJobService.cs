using JobMatching.Application.DTO.Job;

namespace JobMatching.Application.Interfaces;

public interface IJobService
{
	Task<List<JobDTO>> GetJobsByEmployerIdAsync(Guid employerId);
	Task<List<JobDTO>> GetJobsAsync();
}

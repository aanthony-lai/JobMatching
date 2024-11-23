using JobMatching.Application.DTO;

namespace JobMatching.Application.Interfaces
{
	public interface IJobService
	{
		Task<JobDTO?> GetJobByIdAsync(Guid jobId);
		Task<List<JobDTO>> GetJobsAsync();
	}
}

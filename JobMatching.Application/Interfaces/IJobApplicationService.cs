using JobMatching.Application.DTO;

namespace JobMatching.Application.Interfaces
{
	public interface IJobApplicationService
	{
		Task<JobApplicationDTO?> GetJobApplicationByIdAsync(Guid jobApplicationId);
		Task<List<JobApplicationDTO>> GetJobApplicationsAsync();
	}
}

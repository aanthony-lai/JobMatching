using JobMatching.Application.DTO.JobApplication;

namespace JobMatching.Application.Interfaces;

public interface IJobApplicationService
{
	Task<List<JobApplicationDTO>> GetJobApplicationsByCandidateIdAsync(Guid jobApplicationId);
	Task<List<JobApplicationDTO>> GetJobApplicationsAsync();
}

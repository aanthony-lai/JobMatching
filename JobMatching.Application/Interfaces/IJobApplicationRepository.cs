using JobMatching.Domain.Entities;

namespace JobMatching.Application.Interfaces
{
	public interface IJobApplicationRepository
	{
		Task<List<JobApplication>> GetJobApplicationsAsync(bool withTracking = true);
		Task<List<JobApplication>> GetJobApplicationsByCandidateIdAsync(Guid jobApplicationId, bool withTracking = true);
		Task<List<JobApplication>> GetApplicantsByJobIdAsync(Guid jobId, bool withTracking = true);
	}
}

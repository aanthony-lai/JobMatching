using JobMatching.Domain.Entities;

namespace JobMatching.Application.Interfaces
{
	public interface IJobApplicationRepository
	{
		Task<List<JobApplication>> GetJobApplicationsAsync(bool withTracking = true);
		Task<JobApplication?> GetJobApplicationByIdAsync(Guid jobApplicationId, bool withTracking = true);
	}
}

using JobMatching.Domain.Entities;

namespace JobMatching.Application.Interfaces;

public interface IJobApplicationRepository
{
	Task<List<JobApplication>> GetJobApplicationsAsync(bool withTracking = true);
	Task<List<JobApplication>> GetJobApplicationsByCandidateIdAsync(Guid jobApplicationId, bool withTracking = true);
	Task<List<JobApplication>> GetJobApplicationsByJobIdAsync(Guid jobId, bool withTracking = true);
	Task AddJobApplicationAsync(JobApplication jobApplication);
}

using JobMatching.Application.DTO.JobApplication;
using JobMatching.Application.Interfaces;
using JobMatching.Application.Utilities;

namespace JobMatching.Application.Services
{
	public class JobApplicationService : IJobApplicationService
	{
		private readonly IJobApplicationRepository _jobApplicationRepository;

		public JobApplicationService(
			IJobApplicationRepository jobApplicationRepository)
		{
			_jobApplicationRepository = jobApplicationRepository;
		}

		public async Task<List<JobApplicationDTO>> GetJobApplicationsByCandidateIdAsync(Guid candidateId)
		{
			var jobApplication = await _jobApplicationRepository.GetJobApplicationsByCandidateIdAsync(candidateId, withTracking: false);

			return JobApplicationMapper.MapJobApplications(jobApplication);
		}

		//Only in prototype
		public async Task<List<JobApplicationDTO>> GetJobApplicationsAsync()
		{
			var jobApplications = await _jobApplicationRepository.GetJobApplicationsAsync(withTracking: false);

			return JobApplicationMapper.MapJobApplications(jobApplications);
		}
	}
}

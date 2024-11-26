using JobMatching.Application.DTO.JobApplication;
using JobMatching.Application.Interfaces;
using JobMatching.Application.Utilities;

namespace JobMatching.Application.Services
{
	public class JobApplicationService : IJobApplicationService
	{
		private readonly IJobApplicationRepository _jobApplicationRepository;

		public JobApplicationService(IJobApplicationRepository jobApplicationRepository)
		{
			_jobApplicationRepository = jobApplicationRepository;
		}

		public async Task<List<JobApplicationDTO>> GetJobApplicationsByCandidateIdAsync(Guid candidateId)
		{
			var jobApplications = await _jobApplicationRepository.GetJobApplicationsByCandidateIdAsync(candidateId, withTracking: false);

			return JobApplicationMapper.MapJobApplications(jobApplications);
		}

		//Only in prototype
		public async Task<List<JobApplicationDTO>> GetJobApplicationsAsync()
		{
			var jobApplications = await _jobApplicationRepository.GetJobApplicationsAsync(withTracking: false);

			return JobApplicationMapper.MapJobApplications(jobApplications);
		}
	}
}

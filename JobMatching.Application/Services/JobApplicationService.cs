using JobMatching.Application.DTO;
using JobMatching.Application.Interfaces;
using JobMatching.Application.Utilities.Mappers;

namespace JobMatching.Application.Services
{
	public class JobApplicationService : IJobApplicationService
	{
		private readonly IJobApplicationRepository _jobApplicationRepository;

		public JobApplicationService(IJobApplicationRepository jobApplicationRepository)
		{
			_jobApplicationRepository = jobApplicationRepository;
		}

		public async Task<JobApplicationDTO?> GetJobApplicationByIdAsync(Guid jobApplicationId)
		{
			var jobApplication = await _jobApplicationRepository.GetJobApplicationByIdAsync(jobApplicationId, withTracking: false);

			if (jobApplication is null)
				return null;

			return JobApplicationMapper.Map(jobApplication);
		}

		public async Task<List<JobApplicationDTO>> GetJobApplicationsAsync()
		{
			var jobApplications = await _jobApplicationRepository.GetJobApplicationsAsync(withTracking: false);

			return JobApplicationsMapper.Map(jobApplications);
		}
	}
}

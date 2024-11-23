using JobMatching.Application.DTO;
using JobMatching.Application.Interfaces;
using JobMatching.Application.Utilities.Mappers;
using JobMatching.Domain.Interfaces;

namespace JobMatching.Application.Services
{
	public class JobApplicationService : IJobApplicationService
	{
		private readonly IJobApplicationRepository _jobApplicationRepository;
		private readonly IJobMatchService _jobMatchService;

		public JobApplicationService(
			IJobApplicationRepository jobApplicationRepository,
			IJobMatchService jobMatchService)
		{
			_jobApplicationRepository = jobApplicationRepository;
			_jobMatchService = jobMatchService;
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

			var test = jobApplications;

			return JobApplicationsMapper.Map(jobApplications);
		}


	}
}

using JobMatching.Application.DTO;
using JobMatching.Application.Interfaces;
using JobMatching.Application.Utilities.Mappers;

namespace JobMatching.Application.Services
{
	public class JobService : IJobService
	{
		private readonly IJobRepository _jobRepository;

		public JobService(IJobRepository jobRepository) 
		{
			_jobRepository = jobRepository;
		}

		public async Task<JobDTO?> GetJobByIdAsync(Guid jobId)
		{
			var job = await _jobRepository.GetJobByIdAsync(jobId, withTracking: false);

			return JobMapper.Map(job);
		}

		public async Task<List<JobDTO>> GetJobsAsync()
		{
			var jobs = await _jobRepository.GetJobsAsync(withTracking: false);

			return JobsMapper.Map(jobs);
		}
	}
}

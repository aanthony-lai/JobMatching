using JobMatching.Application.DTO.Job;
using JobMatching.Application.Interfaces;
using JobMatching.Application.Utilities;
using JobMatching.Domain.Entities;
using JobMatching.Domain.ValueObjects;

namespace JobMatching.Application.Services
{
	public class JobService : IJobService
	{
		private readonly IJobRepository _jobRepository;

		public JobService(
			IJobRepository jobRepository)
		{
			_jobRepository = jobRepository;
		}

		public async Task<List<JobDTO>> GetJobsByEmployerIdAsync(Guid employerId)
		{
			var jobs = await _jobRepository.GetJobsByEmployerIdAsync(employerId, withTracking: false);
			return JobMapper.MapJobs(jobs);
		}

		public async Task<List<JobDTO>> GetJobsAsync()
		{
			var jobs = await _jobRepository.GetJobsAsync(withTracking: false);
			return JobMapper.MapJobs(jobs);
		}

		public async Task PostJobAsync(CreateJobDTO createJobDto)
		{
			await _jobRepository.SaveJobAsync(new Job(
				jobTitle: createJobDto.jobTitle,
				employerId: createJobDto.EmployerId,
				salaryRange: createJobDto.salaryRange ?? null));
		}
	}
}

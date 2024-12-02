using JobMatching.Application.DTO.JobApplication;
using JobMatching.Application.Exceptions;
using JobMatching.Application.Interfaces;
using JobMatching.Application.Utilities;
using JobMatching.Common.SystemMessages.CandidateMessages;
using JobMatching.Common.SystemMessages.JobMessages;
using JobMatching.Domain.Entities;

namespace JobMatching.Application.Services
{
	public class JobApplicationService : IJobApplicationService
	{
		private readonly IJobApplicationRepository _jobApplicationRepository;
		private readonly IJobRepository _jobRepository;
		private readonly ICandidateRepository _candidateRepository;

		public JobApplicationService(
			IJobApplicationRepository jobApplicationRepository,
			IJobRepository jobRepository,
			ICandidateRepository candidateRepository)
		{
			_jobApplicationRepository = jobApplicationRepository;
			_jobRepository = jobRepository;
			_candidateRepository = candidateRepository;
		}

		//Only in prototype
		public async Task<List<JobApplicationDTO>> GetJobApplicationsAsync()
		{
			var jobApplications = await _jobApplicationRepository.GetJobApplicationsAsync(withTracking: false);

			return JobApplicationMapper.MapJobApplications(jobApplications);
		}

		public async Task<List<JobApplicationDTO>> GetJobApplicationsByCandidateIdAsync(Guid candidateId)
		{
			var jobApplications = await _jobApplicationRepository.GetJobApplicationsByCandidateIdAsync(candidateId, withTracking: false);

			return JobApplicationMapper.MapJobApplications(jobApplications);
		}

		public async Task CreateJobApplicationAsync(CreateJobApplicationDTO createJobApplicationDto)
		{
			Candidate candidate = await _candidateRepository.GetCandidateByIdAsync(createJobApplicationDto.CandidateId)
				?? throw new CandidateNotFoundException(
					CandidateMessages.CandidateNotFound(createJobApplicationDto.CandidateId));

			Job job = await _jobRepository.GetJobByIdAsync(createJobApplicationDto.JobId)
				?? throw new JobNotFoundException(
					JobMessages.JobNotFound(createJobApplicationDto.JobId));
			
			await _jobApplicationRepository.CreateJobApplicationAsync(new JobApplication(candidate, job));
		}
	}
}

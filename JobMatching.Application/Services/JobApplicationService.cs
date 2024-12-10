using JobMatching.Application.DTO.JobApplication;
using JobMatching.Application.Interfaces;
using JobMatching.Application.Utilities;
using JobMatching.Common.Results;
using JobMatching.Domain.Entities;
using JobMatching.Domain.Errors;

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
        public async Task<List<JobApplicationDTO>> GetAllAsync()
        {
            var jobApplications = await _jobApplicationRepository.GetJobApplicationsAsync(withTracking: false);

            return JobApplicationMapper.MapJobApplications(jobApplications);
        }

        public async Task<List<JobApplicationDTO>> GetByCandidateIdAsync(Guid candidateId)
        {
            var jobApplications = await _jobApplicationRepository.GetJobApplicationsByCandidateIdAsync(candidateId, withTracking: false);

            return JobApplicationMapper.MapJobApplications(jobApplications);
        }

        public async Task<Result<JobApplication>> AddAsync(CreateJobApplicationDTO dto)
        {
            if (!await _candidateRepository.ExistsAsync(dto.CandidateId))
                return Result<JobApplication>.Failure(CandidateErrors.NotFound);

            if (!await _jobRepository.ExistsAsync(dto.JobId))
                return Result<JobApplication>.Failure(JobErrors.NotFound);

            Result<JobApplication> applicationResult = JobApplication.Create(dto.CandidateId, dto.JobId);

            if (!applicationResult.IsSuccess)
                return Result<JobApplication>.Failure(applicationResult.Error);

            await _jobApplicationRepository.AddJobApplicationAsync(applicationResult.Value);
            return Result<JobApplication>.Success(applicationResult.Value);
        }
    }
}

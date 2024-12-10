using JobMatching.Application.DTO.Job;
using JobMatching.Application.Interfaces;
using JobMatching.Application.Utilities;
using JobMatching.Common.Results;
using JobMatching.Domain.Entities;
using JobMatching.Domain.Entities.JunctionEntities;
using JobMatching.Domain.Errors;

namespace JobMatching.Application.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;
        private readonly ICompetenceRepository _competenceRepository;

        public JobService(
            IJobRepository jobRepository,
            ICompetenceRepository competenceRepository)
        {
            _jobRepository = jobRepository;
            _competenceRepository = competenceRepository;
        }

        public async Task<List<JobDTO>> GetByJobTitleAsync(string jobTitle)
        {
            var jobs = await _jobRepository.GetByJobTitleAsync(jobTitle, withTracking: false);
            return JobMapper.MapJobs(jobs);
        }

        public async Task<List<JobDTO>> GetJobsAsync()
        {
            var jobs = await _jobRepository.GetAllAsync(withTracking: false);
            return JobMapper.MapJobs(jobs);
        }

        public async Task<Result<Job>> AddAsync(CreateJobDTO dto)
        {
            Result<Job> createJobResult = Job.Create(
                dto.EmployerId,
                dto.Title,
                dto.Salary);

            if (!createJobResult.IsSuccess)
                return Result<Job>.Failure(createJobResult.Error);

            var job = await _jobRepository.AddAsync(createJobResult.Value);
            return Result<Job>.Success(job);
        }

        public async Task<Result<JobCompetence>> AddJobCompetence(Guid jobId, AddJobCompetenceDTO dto)
        {
            if (!await _jobRepository.ExistsAsync(jobId))
                return Result<JobCompetence>.Failure(JobErrors.NotFound);

            if (!await _competenceRepository.ExistsAsync(dto.CompetenceId))
                return Result<JobCompetence>.Failure(JobErrors.NotFound);

            var jobCompetence = await _jobRepository.AddJobCompetenceAsync(
                new JobCompetence(jobId, dto.CompetenceId, dto.IsCritical));

            return Result<JobCompetence>.Success(jobCompetence);
        }
    }
}

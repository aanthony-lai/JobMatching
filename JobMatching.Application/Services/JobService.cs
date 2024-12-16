using JobMatching.Application.DTO.Job;
using JobMatching.Application.Interfaces.Mappers;
using JobMatching.Application.Interfaces.Services;
using JobMatching.Common.Results;
using JobMatching.Domain.Entities.Job;
using JobMatching.Domain.Errors;
using JobMatching.Domain.Repositories;

namespace JobMatching.Application.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;
        private readonly IJobMapper _jobMapper;

        public JobService(
            IJobRepository jobRepository,
            IJobMapper jobMapper)
        {
            _jobRepository = jobRepository;
            _jobMapper = jobMapper;
        }

        public async Task<Result<List<JobDTO>>> GetAsync()
        {
            var jobs = await _jobRepository.GetAsync();

            var jobsDto = jobs
                .Select(job => _jobMapper
                .ToDto(job))
                .ToList();

            return Result<List<JobDTO>>.Success(jobsDto);
        }

        public async Task<Result<JobDTO>> GetByIdAsync(Guid jobId)
        {
            var job = await _jobRepository.GetByIdAsync(jobId);

            if (job is null)
                return Result<JobDTO>.Failure(JobErrors.NotFound);

            var jobDto = _jobMapper.ToDto(job);

            return Result<JobDTO>.Success(jobDto);
        }



        public async Task<List<JobDTO>> GetByNameAsync(string name)
        {
            var jobs = await _jobRepository.GetByNameAsync(name);

            if (!jobs.Any())
                return new List<JobDTO>();

            return jobs.Select(job => _jobMapper.ToDto(job)).ToList();
        }

        public async Task<Result<Job>> AddAsync(Guid employerId, CreateJobDTO createJobDto)
        {
            var addJobResult = Job.Create(
                createJobDto.Title, 
                createJobDto.MaxSalary, 
                createJobDto.MinSalary, 
                employerId, 
                createJobDto.Description);

            if (!addJobResult.IsSuccess)
                return Result<Job>.Failure(addJobResult.Error);

            await _jobRepository.SaveAsync(addJobResult.Value);
            return Result<Job>.Success(addJobResult.Value);
        }
    }
}

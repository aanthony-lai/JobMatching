using JobMatching.Application.DTO.Job;
using JobMatching.Application.Interfaces;
using JobMatching.Application.Utilities;
using JobMatching.Common.Exceptions;
using JobMatching.Domain.Entities;

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
            var jobs = await _jobRepository.GetJobsAsync(withTracking: false);
            return JobMapper.MapJobs(jobs);
        }

        public async Task PostJobAsync(CreateJobDTO createJobDto)
        {
            await _jobRepository.AddJobAsync(CreateJobDTOMapper.MapCreateJobDTO(createJobDto));
        }

        public async Task AddJobCompetence(AddJobCompetenceDTO addJobCompetenceDTO)
        {
            var job = await _jobRepository.GetJobByIdAsync(addJobCompetenceDTO.JobId)
                ?? throw new EntityNotFoundException("The selected job doesn't exist.");

            job.AddCompetence(addJobCompetenceDTO.CompetenceId, addJobCompetenceDTO.IsCritical);

            await _jobRepository.UpdateJobAsync(job);
        }
    }
}

using JobMatching.Application.DTO.Job;
using JobMatching.Common.Results;
using JobMatching.Domain.Entities;
using JobMatching.Domain.Entities.JunctionEntities;

namespace JobMatching.Application.Interfaces;

public interface IJobService
{
	Task<List<JobDTO>> GetByJobTitleAsync(string jobTitle);
	Task<List<JobDTO>> GetJobsAsync();
	Task<Result<Job>> AddAsync(CreateJobDTO dto);
    Task<Result<JobCompetence>> AddJobCompetence(Guid jobId, AddJobCompetenceDTO dto);
}

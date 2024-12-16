using JobMatching.Application.DTO.Job;
using JobMatching.Common.Results;
using JobMatching.Domain.Entities.Job;

namespace JobMatching.Application.Interfaces.Services;

public interface IJobService
{
    Task<Result<List<JobDTO>>> GetAsync();
    Task<Result<JobDTO>> GetByIdAsync(Guid jobId);
    Task<List<JobDTO>> GetByNameAsync(string name);
    Task<Result<Job>> AddAsync(Guid employerId, CreateJobDTO createJobDto);
}
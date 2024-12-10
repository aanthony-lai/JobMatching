using JobMatching.Domain.Entities;
using JobMatching.Domain.Entities.JunctionEntities;

namespace JobMatching.Application.Interfaces;

public interface IJobRepository
{
	Task<Job?> GetByIdAsync(Guid jobId, bool withTracking = true);
	Task<List<Job>> GetByJobTitleAsync(string jobTitle, bool withTracking = true);
	Task<List<Job>> GetAllAsync(bool withTracking = true);
    Task<Job> AddAsync(Job job);
	Task<JobCompetence> AddJobCompetenceAsync(JobCompetence jobCompetence);
    Task UpdateJobAsync(Job job);
    Task<bool> ExistsAsync(Guid jobId);
}

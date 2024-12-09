using JobMatching.Application.DTO.Job;

namespace JobMatching.Application.Interfaces;

public interface IJobService
{
	Task<List<JobDTO>> GetByJobTitleAsync(string jobTitle);
	Task<List<JobDTO>> GetJobsAsync();
	Task PostJobAsync(CreateJobDTO createJobDto);
	Task AddJobCompetence(AddJobCompetenceDTO addJobCompetenceDTO);
}

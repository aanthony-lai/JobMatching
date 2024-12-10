using JobMatching.Application.DTO.JobApplication;
using JobMatching.Common.Results;
using JobMatching.Domain.Entities;

namespace JobMatching.Application.Interfaces;

public interface IJobApplicationService
{
	Task<List<JobApplicationDTO>> GetByCandidateIdAsync(Guid jobApplicationId);
	Task<List<JobApplicationDTO>> GetAllAsync();
	Task<Result<JobApplication>> AddAsync(CreateJobApplicationDTO dto);
}

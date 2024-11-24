using JobMatching.Application.DTO.Candidate;
using JobMatching.Application.DTO.Employer;
using JobMatching.Domain.Enums;

namespace JobMatching.Application.DTO.JobApplication
{
	public record JobApplicationDTO(
		Guid jobApplicationId,
		CandidateDTO candidate,
		JobDTO job,
		DateTime applicationDate,
		ApplicationStatus status);
}

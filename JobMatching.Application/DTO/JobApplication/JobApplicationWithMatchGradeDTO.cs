using JobMatching.Application.DTO.Candidate;
using JobMatching.Application.DTO.Employer;
using JobMatching.Domain.Enums;

namespace JobMatching.Application.DTO.JobApplication
{
	public record JobApplicationWithMatchGradeDTO(
		Guid jobApplicationId,
		CandidateDTO candidate,
		JobDTO job,
		DateTime applicationDate,
		ApplicationStatus status,
		decimal matchGrade);
}

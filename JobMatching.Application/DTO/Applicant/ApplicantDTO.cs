using JobMatching.Application.DTO.Candidate;
using JobMatching.Application.DTO.Employer;
using JobMatching.Domain.Enums;

namespace JobMatching.Application.DTO.Applicant
{
	public record ApplicantDTO(
		Guid jobApplicationId,
		CandidateDTO candidate,
		EmployerJobDTO job,
		DateTime applicationDate,
		ApplicationStatus status)
	{
		public bool MeetsCriticalCompetences { get; set; } = false;
		public string CriticalCompetencesMatchSummary { get; set; } = string.Empty;
		public decimal OverallMatchGrade { get; set; } = 0m;
	}
}

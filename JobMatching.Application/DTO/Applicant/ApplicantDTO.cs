using JobMatching.Application.DTO.Employer;
using JobMatching.Application.DTO.JobApplication;
using JobMatching.Domain.Enums;

namespace JobMatching.Application.DTO.Applicant
{
    public record ApplicantDTO(
        Guid JobApplicationId,
        JobApplicationCandidateDTO Candidate,
        EmployerJobDTO Job,
        DateTime ApplicationDate,
        ApplicationStatus Status)
    {
        public bool MeetsCriticalCompetences { get; set; } = false;
        public string CriticalCompetencesMatchSummary { get; set; } = string.Empty;
        public decimal OverallMatchGrade { get; set; } = 0m;
    }
}

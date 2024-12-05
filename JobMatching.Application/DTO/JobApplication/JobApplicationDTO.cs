using JobMatching.Application.DTO.Employer;
using JobMatching.Domain.Enums;

namespace JobMatching.Application.DTO.JobApplication
{
    public record JobApplicationDTO(
        Guid JobApplicationId,
        JobApplicationCandidateDTO Candidate,
        EmployerJobDTO Job,
        DateTime ApplicationDate,
        ApplicationStatus Status);
}

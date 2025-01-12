using JobMatching.Domain.Enums;

namespace JobMatching.Application.CandidateServices
{
    public record JobApplicationDTO(
        Guid JobId,
        ApplicationStatus Status,
        DateTime ApplicationDate);
}

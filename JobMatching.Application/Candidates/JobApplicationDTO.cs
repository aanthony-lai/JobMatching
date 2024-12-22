using JobMatching.Domain.Enums;

namespace JobMatching.Application.Candidates
{
    public record JobApplicationDTO(
        Guid JobId,
        ApplicationStatus Status,
        DateTime ApplicationDate);
}

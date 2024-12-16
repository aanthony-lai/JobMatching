using JobMatching.Domain.Enums;

namespace JobMatching.Application.DTO.Candidate
{
    public record JobApplicationDTO(
        Guid JobId,
        ApplicationStatus Status,
        DateTime ApplicationDate);
}

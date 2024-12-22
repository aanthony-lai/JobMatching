using JobMatching.Domain.Enums;

namespace JobMatching.Application.DTO.Candidate
{
    public record CandidateCompetenceDTO(
        Guid CompetenceId,
        CompetenceLevel CompetenceLevel);
}

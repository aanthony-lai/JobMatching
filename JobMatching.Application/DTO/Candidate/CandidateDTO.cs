using JobMatching.Application.DTO.Shared;

namespace JobMatching.Application.DTO.Candidate
{
    public record CandidateDTO(
        Guid candidateId,
        string firstName,
        string lastName,
        List<CompetenceDTO> competences);
}

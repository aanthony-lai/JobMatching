using JobMatching.Application.DTO.Shared;

namespace JobMatching.Application.DTO.Candidate
{
    public record CandidateDTO(
        Guid CandidateId,
        string FirstName,
        string LastName,
        List<CompetenceDTO> Competences,
        List<CandidateLanguageDTO> Languages);
}

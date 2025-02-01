using JobMatching.Application.CandidateServices;

namespace JobMatching.Application.DTO.Candidate
{
    public record CandidateDTO(
        Guid Id,
        string FullName,
        IEnumerable<Guid> JobApplicationIds,
        IEnumerable<Guid> LanguageIds,
        IEnumerable<Guid> CompetenceIds);
}

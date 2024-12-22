using JobMatching.Application.Candidates;

namespace JobMatching.Application.DTO.Candidate
{
    public record CandidateDTO(
        Guid Id,
        string FullName,
        IReadOnlyList<JobApplicationDTO> JobApplication,
        IReadOnlyList<CandidateLanguageDTO> LanguageSkills,
        IReadOnlyList<CandidateCompetenceDTO> Competences);
}

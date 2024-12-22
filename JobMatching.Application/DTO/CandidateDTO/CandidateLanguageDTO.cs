using JobMatching.Domain.Enums;

namespace JobMatching.Application.DTO.Candidate
{
    public record CandidateLanguageDTO(
        Guid LanguageId,
        LanguageProficiencyLevel ProficiencyLevel);
}

using JobMatching.Domain.Enums;

namespace JobMatching.Domain.Entities.JunctionEntities;

public class CandidateLanguage
{
    public Guid CandidateId { get; }
    public Candidate Candidate { get; } = null!;
    public Guid LanguageId { get; private set; }
    public Language Language { get; } = null!;
    public LanguageProficiencyLevel ProficiencyLevel { get; private set; }

    protected CandidateLanguage() { }
    public CandidateLanguage(
        Guid candidateId,
        Guid languageId,
        LanguageProficiencyLevel proficiencyLevel = LanguageProficiencyLevel.NotSpecified)
    {
        CandidateId = candidateId;
        LanguageId = languageId;
        ProficiencyLevel = proficiencyLevel;
    }
}
using JobMatching.Domain.Types;

namespace JobMatching.Domain.Entities.JunctionEntities;

public class CandidateLanguage
{
    public Guid CandidateId { get; }
    public Candidate Candidate { get; }
    public Guid LanguageId { get; private set; }
    public Language Language { get; }
    public LanguageProficiencyLevel? ProficiencyLevel { get; private set; }

    protected CandidateLanguage() { }
    public CandidateLanguage(Guid candidateId, Guid languageId, LanguageProficiencyLevel? proficiencyLevel)
    {
        CandidateId = candidateId == Guid.Empty
            ? throw new ArgumentException("Invalid candidate ID.", nameof(candidateId))
            : candidateId;
		LanguageId = languageId == Guid.Empty
			? throw new ArgumentException("Invalid language ID.", nameof(languageId))
			: languageId;

        ProficiencyLevel = proficiencyLevel;
    }
}
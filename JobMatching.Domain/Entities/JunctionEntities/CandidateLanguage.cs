namespace JobMatching.Domain.Entities.JunctionEntities;

public class CandidateLanguage
{
    public Guid CandidateId { get; }
    public Candidate Candidate { get; }
    public Guid LanguageId { get; }
    public Language Language { get; }
}
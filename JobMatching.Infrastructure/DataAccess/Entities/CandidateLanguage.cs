using JobMatching.Domain.Enums;

namespace JobMatching.Infrastructure.DataAccess.Entities
{
    public class CandidateLanguage
    {
        public Guid CandidateId { get; set; }
        public Guid LanguageId { get; set; }
        public LanguageProficiencyLevel ProficiencyLevel { get; set; }
        public CandidateEntity Candidate { get; set; } = null!;
        public LanguageEntity Language { get; set; } = null!;
    }
}

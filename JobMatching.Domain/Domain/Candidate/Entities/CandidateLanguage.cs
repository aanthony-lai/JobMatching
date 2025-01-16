using JobMatching.Common.Results;
using JobMatching.Domain.Enums;
using JobMatching.Domain.Errors;

namespace JobMatching.Domain.Domain.Candidate.Entities
{
    public class CandidateLanguage
    {
        public Guid LanguageId { get; }
        public string Name { get; }
        public LanguageProficiencyLevel ProficiencyLevel { get; private set; }

        protected CandidateLanguage() { }
        private CandidateLanguage(
            Guid languageId,
            string name,
            LanguageProficiencyLevel proficiencyLevel)
        {
            LanguageId = languageId;
            Name = name;
            ProficiencyLevel = proficiencyLevel;
        }

        public static Result<CandidateLanguage> Create(
            Guid languageId,
            string name,
            LanguageProficiencyLevel proficiencyLevel =
            LanguageProficiencyLevel.NotSpecified)
        {
            if (languageId == Guid.Empty)
                return Result<CandidateLanguage>.Failure(CandidateErrors.InvalidLanguage);

            return Result<CandidateLanguage>.Success(
                new CandidateLanguage(
                    languageId,
                    name,
                    proficiencyLevel));
        }
    }
}

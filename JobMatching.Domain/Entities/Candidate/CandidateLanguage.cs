using JobMatching.Common.Results;
using JobMatching.Domain.Enums;
using JobMatching.Domain.Errors;

namespace JobMatching.Domain.Entities.Candidate
{
    public class CandidateLanguage: IEquatable<CandidateLanguage>
    {
        public Guid CandidateId { get; private set; }
        public Guid LanguageId { get; private set; }
        public LanguageProficiencyLevel ProficiencyLevel { get; private set; }

        protected CandidateLanguage() { }
        private CandidateLanguage(
            Guid candidateId, 
            Guid languageId, 
            LanguageProficiencyLevel proficiencyLevel)
        {
            CandidateId = candidateId;
            LanguageId = languageId;
            ProficiencyLevel = proficiencyLevel;
        }

        public static Result<CandidateLanguage> Create(
            Guid candidateId,
            Guid languageId,
            LanguageProficiencyLevel proficiencyLevel = 
            LanguageProficiencyLevel.NotSpecified)
        {
            if (languageId == Guid.Empty)
                return Result<CandidateLanguage>.Failure(CandidateErrors.InvalidLanguage);

            return Result<CandidateLanguage>.Success(
                new CandidateLanguage(
                    candidateId,
                    languageId,
                    proficiencyLevel));
        }

        public bool Equals(CandidateLanguage? other)
        {
            return this.CandidateId == other.CandidateId && this.LanguageId == other.LanguageId;
        }
    }
}

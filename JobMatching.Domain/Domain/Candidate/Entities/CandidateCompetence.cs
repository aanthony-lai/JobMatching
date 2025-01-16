using JobMatching.Common.Results;
using JobMatching.Domain.Enums;
using JobMatching.Domain.Errors;

namespace JobMatching.Domain.Domain.Candidate.Entities
{
    public class CandidateCompetence
    {
        public Guid CompetenceId { get; private set; }
        public string CompetenceName { get; private set; } = null!;
        public CompetenceLevel CompetenceLevel { get; private set; }

        protected CandidateCompetence() { }
        private CandidateCompetence(
            Guid competenceId,
            string CompetenceName,
            CompetenceLevel competenceLevel)
        {
            CompetenceId = competenceId;
            CompetenceLevel = competenceLevel;
        }

        public static Result<CandidateCompetence> Create(
            Guid competenceId,
            string competenceName,
            CompetenceLevel competenceLevel =
            CompetenceLevel.NotSpecified)
        {
            return Result<CandidateCompetence>.Success(
                new CandidateCompetence(
                    competenceId,
                    competenceName,
                    competenceLevel));
        }
    }
}

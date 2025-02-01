using JobMatching.Common.Results;
using JobMatching.Domain.Enums;

namespace JobMatching.Domain.Domain.Candidate.Entities
{
    public class CandidateCompetence
    {
        public Guid CompetenceId { get; }
        public string CompetenceName { get; }
        public CompetenceLevel CompetenceLevel { get; }

        private CandidateCompetence(
            Guid competenceId,
            string competenceName,
            CompetenceLevel competenceLevel)
        {
            CompetenceId = competenceId;
            CompetenceName = competenceName;
            CompetenceLevel = competenceLevel;
        }

        public static Result<CandidateCompetence> Create(
            Guid competenceId,
            string competenceName,
            CompetenceLevel competenceLevel = CompetenceLevel.NotSpecified)
        {
            return Result<CandidateCompetence>.Success(
                new CandidateCompetence(
                    competenceId,
                    competenceName,
                    competenceLevel));
        }

        public static CandidateCompetence Load(
            Guid competenceId,
            string competenceName,
            CompetenceLevel competenceLevel) 
        {
            return new CandidateCompetence(
                competenceId, 
                competenceName, 
                competenceLevel);
        } 
    }
}

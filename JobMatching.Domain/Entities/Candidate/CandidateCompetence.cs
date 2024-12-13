using JobMatching.Common.Results;
using JobMatching.Domain.Enums;
using JobMatching.Domain.Errors;

namespace JobMatching.Domain.Entities.Candidate
{
    public class CandidateCompetence: IEquatable<CandidateCompetence>
    {
        public Guid CandidateId { get; private set; }
        public Guid CompetenceId { get; private set; }
        public CompetenceLevel CompetenceLevel { get; private set; }

        protected CandidateCompetence() { }
        private CandidateCompetence(
            Guid candidateId, 
            Guid competenceId, 
            CompetenceLevel competenceLevel)
        {
            CandidateId = candidateId;
            CompetenceId = competenceId;
            CompetenceLevel = competenceLevel;
        }

        public static Result<CandidateCompetence> Create(
            Guid candidateId, 
            Guid competenceId, 
            CompetenceLevel competenceLevel = 
            CompetenceLevel.NotSpecified)
        {
            if (candidateId == Guid.Empty)
                return Result<CandidateCompetence>.Failure(CandidateErrors.InvalidCompetence);

            return Result<CandidateCompetence>.Success(
                new CandidateCompetence(
                    candidateId, 
                    competenceId, 
                    competenceLevel));
        }

        public bool Equals(CandidateCompetence other)
        {
            return this.CandidateId == other.CandidateId && this.CompetenceId == other.CompetenceId;
        }
    }
}

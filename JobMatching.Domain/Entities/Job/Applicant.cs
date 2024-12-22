using JobMatching.Common.Results;
using JobMatching.Domain.Errors;

namespace JobMatching.Domain.Entities.Job
{
    public class Applicant: IEquatable<Applicant>
    {
        public Guid JobId { get; private set; }
        public Guid CandidateId { get; private set; }

        protected Applicant() { }
        private Applicant(Guid jobId, Guid candidateId) 
        {
            JobId = jobId;
            CandidateId = candidateId;
        }

        public static Result<Applicant> Create(
            Guid jobId, 
            Guid candidateId)
        {
            if (candidateId == Guid.Empty)
                return Result<Applicant>.Failure(JobErrors.InvalidCandidate);

            return Result<Applicant>.Success(new Applicant(jobId, candidateId));
        }

        public bool Equals(Applicant? other) => 
            this.JobId == other?.JobId &&
            this.CandidateId == other.CandidateId;
    }
}

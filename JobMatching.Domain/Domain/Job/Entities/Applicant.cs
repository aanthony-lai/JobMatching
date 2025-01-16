using JobMatching.Common.Results;
using JobMatching.Domain.Errors;

namespace JobMatching.Domain.Domain.Job.Entities
{
    public class Applicant
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
    }
}

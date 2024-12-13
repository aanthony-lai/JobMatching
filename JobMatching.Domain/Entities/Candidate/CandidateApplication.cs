using JobMatching.Common.Results;
using JobMatching.Domain.BaseClasses;
using JobMatching.Domain.Enums;
using JobMatching.Domain.Errors;

namespace JobMatching.Domain.Entities.Candidate
{
    public class CandidateApplication : AuditableEntityBase, IEquatable<CandidateApplication>
    {
        public Guid CandidateId { get; private set; }
        public Guid JobId { get; private set; }
        public ApplicationStatus Status { get; private set; }
        public DateTime ApplicationDate { get; private set; }

        private CandidateApplication(Guid candidateId, Guid jobId) : base()
        {
            Id = Guid.NewGuid();
            CandidateId = candidateId;
            JobId = jobId;
            Status = ApplicationStatus.Pending;
            ApplicationDate = DateTime.UtcNow;
        }

        public static Result<CandidateApplication> Create(Guid candidateId, Guid jobId)
        {
            if (candidateId == Guid.Empty)
                return Result<CandidateApplication>.Failure(JobApplicationErrors.InvalidCandidateId);

            if (jobId == Guid.Empty)
                return Result<CandidateApplication>.Failure(JobApplicationErrors.InvalidJobId);

            return Result<CandidateApplication>.Success(new CandidateApplication(candidateId, jobId));
        }

        public bool Equals(CandidateApplication other) =>
            this.CandidateId == other.CandidateId &&
            this.JobId == other.JobId;
    }
}

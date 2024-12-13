using JobMatching.Common.Results;
using JobMatching.Domain.BaseClasses;
using JobMatching.Domain.Enums;
using JobMatching.Domain.Errors;

namespace JobMatching.Domain.Entities.Candidate
{
    public class JobApplication : AuditableEntityBase, IEquatable<JobApplication>
    {
        public Guid CandidateId { get; private set; }
        public Guid JobId { get; private set; }
        public ApplicationStatus Status { get; private set; }
        public DateTime ApplicationDate { get; private set; }

        private JobApplication(Guid candidateId, Guid jobId) : base()
        {
            Id = Guid.NewGuid();
            CandidateId = candidateId;
            JobId = jobId;
            Status = ApplicationStatus.Pending;
            ApplicationDate = DateTime.UtcNow;
        }

        public static Result<JobApplication> Create(Guid candidateId, Guid jobId)
        {
            if (candidateId == Guid.Empty)
                return Result<JobApplication>.Failure(JobApplicationErrors.InvalidCandidateId);

            if (jobId == Guid.Empty)
                return Result<JobApplication>.Failure(JobApplicationErrors.InvalidJobId);

            return Result<JobApplication>.Success(new JobApplication(candidateId, jobId));
        }

        public bool Equals(JobApplication other) =>
            this.CandidateId == other.CandidateId &&
            this.JobId == other.JobId;
    }
}

using JobMatching.Common.Results;
using JobMatching.Domain.Enums;
using JobMatching.Domain.Errors;
using JobMatching.Domain.Interfaces;
using JobMatching.Domain.ValueObjects;

namespace JobMatching.Domain.Entities
{
    public class JobApplication : IEntity
    {
        public Guid Id { get; init; }
        public Guid CandidateId { get; init; }
        public Candidate Candidate { get; private set; } = null!;
        public Guid JobId { get; init; }
        public Job Job { get; private set; } = null!;
        public DateTime ApplicationDate { get; private set; }
        public ApplicationStatus ApplicationStatus { get; private set; }
        public MetaData MetaData { get; private set; } = null!;

        protected JobApplication() { }
        private JobApplication(Guid candidateId, Guid jobId)
        {
            Id = Guid.NewGuid();
            CandidateId = candidateId;
            JobId = jobId;
            ApplicationDate = DateTime.UtcNow;
            ApplicationStatus = ApplicationStatus.Pending;
            MetaData = new MetaData();
        }

        public static Result<JobApplication> Create(Guid candidateId, Guid jobId)
        {
            if (candidateId == Guid.Empty)
                return Result<JobApplication>.Failure(JobApplicationErrors.InvalidCandidateId);

            if (jobId == Guid.Empty)
                return Result<JobApplication>.Failure(JobApplicationErrors.InvalidJobId);

            return Result<JobApplication>.Success(new JobApplication(candidateId, jobId));
        }
    }
}
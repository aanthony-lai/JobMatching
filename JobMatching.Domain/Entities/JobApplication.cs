using JobMatching.Domain.Enums;
using JobMatching.Domain.Interfaces;
using JobMatching.Domain.ValueObjects;

namespace JobMatching.Domain.Entities
{
    public class JobApplication : IEntity
    {
        public Guid Id { get; init; }
        public Guid CandidateId { get; init; }
        public Candidate Candidate { get; private set; }
        public Guid JobId { get; init; }
        public Job Job { get; private set; } = null!;
        public DateTime ApplicationDate { get; private set; }
        public ApplicationStatus ApplicationStatus { get; private set; }
        public MetaData MetaData { get; private set; } = null!;

        protected JobApplication() { }

        public JobApplication(Guid candidateId, Guid jobId)
        {
            if (candidateId == Guid.Empty)
                throw new ArgumentException(nameof(candidateId),
                    "An application must contain a valid candidate ID.");

            if (jobId == Guid.Empty)
                throw new ArgumentException(nameof(jobId),
                    "An application must contain a valid job ID.");

            Id = Guid.NewGuid();
            CandidateId = candidateId;
            JobId = jobId;
            ApplicationDate = DateTime.UtcNow;
            ApplicationStatus = ApplicationStatus.Pending;
            MetaData = new MetaData();
        }
    }
}

using JobMatching.Domain.Enums;

namespace JobMatching.Infrastructure.DataAccess.Entities
{
    public class JobApplicationEntity: AuditableEntityBase
    {
        public Guid JobId { get; set; } 
        public Guid CandidateId { get; set; }
        public ApplicationStatus Status { get; set; } 
        public JobEntity Job { get; set; } = null!;
        public CandidateEntity Candidate { get; set; } = null!;
    }
}

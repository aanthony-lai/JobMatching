using JobMatching.Common.Results;
using JobMatching.Domain.Enums;
using JobMatching.Domain.Errors;

namespace JobMatching.Domain.Entities.JobApplication
{
    public class JobApplication : DomainEntityBase
    {
        public Guid CandidateId { get; private set; }
        public Guid JobId { get; private set; }
        public ApplicationStatus Status { get; private set; }
        public DateTime ApplicationDate { get; private set; }

        private JobApplication(Guid candidateId, Guid jobId)
        {
            Id = Guid.NewGuid();
            CandidateId = candidateId;
            JobId = jobId;
            Status = ApplicationStatus.Pending;
            ApplicationDate = DateTime.UtcNow;
        }

        private JobApplication(
            Guid Id, 
            Guid candidateId, 
            Guid jobId, 
            ApplicationStatus status,
            DateTime applicationDate) 
        {
            base.Id = Id;
            CandidateId= candidateId;
            JobId= jobId;
            Status = status;
            ApplicationDate = applicationDate;
        }

        public static Result<JobApplication> Create(Guid candidateId, Guid jobId)
        {
            if (candidateId == Guid.Empty)
                return Result<JobApplication>.Failure(JobApplicationErrors.InvalidCandidateId);

            if (jobId == Guid.Empty)
                return Result<JobApplication>.Failure(JobApplicationErrors.InvalidJobId);

            return Result<JobApplication>.Success(new JobApplication(candidateId, jobId));
        }

        public static JobApplication Load(
            Guid Id,
            Guid candidateId,
            Guid jobId,
            ApplicationStatus status,
            DateTime applicationDate)
        {
            return new JobApplication(Id, candidateId, jobId, status, applicationDate);
        }
    }
}

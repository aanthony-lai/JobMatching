using JobMatching.Common.Results;
using JobMatching.Domain.Errors;

namespace JobMatching.Domain.Entities.Job
{
    public class JobEmployer: IEquatable<JobEmployer>
    {
        public Guid JobId { get; set; }
        public Guid EmployerId { get; set; }

        protected JobEmployer() { }
        private JobEmployer(
            Guid jobId, 
            Guid employerId)
        {
            JobId = jobId;
            EmployerId = employerId;
        }

        public static Result<JobEmployer> Create(
            Guid jobId, 
            Guid employerId)
        {
            if (employerId == Guid.Empty)
                return Result<JobEmployer>.Failure(JobErrors.InvalidEmployer);

            return Result<JobEmployer>.Success(
                new JobEmployer(jobId, employerId));
        }

        public bool Equals(JobEmployer other) => 
            this.JobId == other.JobId &&
            this.EmployerId == other.EmployerId;
    }
}

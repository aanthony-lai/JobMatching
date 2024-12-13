using JobMatching.Common.Results;
using JobMatching.Domain.Errors;

namespace JobMatching.Domain.Entities.Employer
{
    public class EmployerJob: IEquatable<EmployerJob>
    {
        public Guid EmployerId { get; private set; }
        public Guid JobId { get; private set; }

        protected EmployerJob() { }
        private EmployerJob(
            Guid employerId, 
            Guid jobId)
        {
            EmployerId = employerId;
            JobId = jobId;
        }

        public static Result<EmployerJob> Create(
            Guid employerId, 
            Guid jobId)
        {
            if (jobId == Guid.Empty)
                return Result<EmployerJob>.Failure(EmployerErrors.InvalidJob);

            return Result<EmployerJob>.Success(new EmployerJob(employerId, jobId));
        }

        public bool Equals(EmployerJob other) => 
            this.EmployerId == other.EmployerId &&
            this.JobId == other.JobId;
    }
}

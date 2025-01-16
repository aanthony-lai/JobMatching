using JobMatching.Common.Results;
using JobMatching.Domain.Errors;

namespace JobMatching.Domain.Domain.Employer.Entities
{
    public class EmployerJob : IEquatable<EmployerJob>
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
            EmployerId == other.EmployerId &&
            JobId == other.JobId;
    }
}

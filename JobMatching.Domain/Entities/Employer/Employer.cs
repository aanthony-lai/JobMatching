using JobMatching.Common.Results;
using JobMatching.Domain.Errors;

namespace JobMatching.Domain.Entities.Employer
{
    public class Employer: AuditableEntityBase
    {
        private readonly List<EmployerJob> _employerJobs = new();

        public string Name { get; private set; } = null!;
        public Guid UserId { get; }
        public IReadOnlyList<EmployerJob> EmployerJobs => _employerJobs.AsReadOnly();

        protected Employer() { }
        private Employer(string name, Guid userId) : base() 
        {
            base.Id = Guid.NewGuid();
            UserId = userId;
            Name = name;
        }
        public static Result<Employer> Create(string name, Guid userId)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Result<Employer>.Failure(EmployerErrors.InvalidName);

            if (userId == Guid.Empty)
                return Result<Employer>.Failure(new Error("You have provided an invalid user ID."));

            return Result<Employer>.Success(new Employer(name, userId));
        }
    }
}

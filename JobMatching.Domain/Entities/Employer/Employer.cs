using JobMatching.Common.Results;
using JobMatching.Domain.BaseClasses;
using JobMatching.Domain.Errors;

namespace JobMatching.Domain.Entities.Employer
{
    public class Employer: AuditableEntityBase
    {
        private readonly List<EmployerJob> _employerJobs = new();

        public string Name { get; private set; } = null!;
        public IReadOnlyList<EmployerJob> EmployerJobs => _employerJobs.AsReadOnly();

        protected Employer() { }
        private Employer(string name) : base() 
        {
            base.Id = Id;
            Name = name;
        }
        public static Result<Employer> Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Result<Employer>.Failure(EmployerErrors.InvalidName);

            return Result<Employer>.Success(new Employer(name));
        }
    }
}

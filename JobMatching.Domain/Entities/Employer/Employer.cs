using JobMatching.Common.Results;
using JobMatching.Domain.BaseClasses;
using JobMatching.Domain.Entities.Users;
using JobMatching.Domain.Errors;

namespace JobMatching.Domain.Entities.Employer
{
    public class Employer: AuditableEntityBase
    {
        private readonly List<EmployerJob> _employerJobs = new();

        public string Name { get; private set; } = null!;
        public Guid UserId { get; private set; }
        public User User { get; private set; } = null!;
        public IReadOnlyList<EmployerJob> EmployerJobs => _employerJobs.AsReadOnly();

        protected Employer() { }
        private Employer(string name, User user) : base() 
        {
            base.Id = Id;
            Name = name;
            User = user;
            UserId = user.Id;
        }
        public static Result<Employer> Create(string name, string email)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Result<Employer>.Failure(EmployerErrors.InvalidName);

            var userResult = User.CreateUserAsCandidate(name, email);
            if (!userResult.IsSuccess)
                return Result<Employer>.Failure(userResult.Error);

            return Result<Employer>.Success(new Employer(name, userResult.Value));
        }
    }
}

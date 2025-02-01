using JobMatching.Common.Results;
using JobMatching.Domain.Entities;
using JobMatching.Domain.Errors;

namespace JobMatching.Domain.Domain.Employer.Entities
{
    public class Employer : DomainEntityBase
    {
        private HashSet<Guid> _jobIds = new();

        public string Name { get; private set; } = null!;
        public Guid UserId { get; }
        public IReadOnlyCollection<Guid> JobIds => _jobIds;

        private Employer(string name, Guid userId)
        {
            base.Id = Guid.NewGuid();
            Name = name;
            UserId = userId;
        }

        private Employer(Guid id, string name, Guid userId)
        {
            base.Id = id;
            Name = name;
            UserId = userId;
        } 

        public static Result<Employer> Create(string name, Guid userId)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Result<Employer>.Failure(EmployerErrors.InvalidName);

            if (userId == Guid.Empty)
                return Result<Employer>.Failure(new Error("You have provided an invalid user ID."));

            return Result<Employer>.Success(new Employer(name, userId));
        }

        public static Employer Load(Guid id, string name, Guid userId)
        {
            return new Employer(id, name, userId);
        }
    }
}

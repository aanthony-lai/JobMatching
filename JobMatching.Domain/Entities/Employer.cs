using JobMatching.Common.Results;
using JobMatching.Domain.Entities.ValueObjects;
using JobMatching.Domain.Enums;
using JobMatching.Domain.Errors;
using JobMatching.Domain.Interfaces;

namespace JobMatching.Domain.Entities
{
    public class Employer : IEntity
    {
        public Guid Id { get; init; }
        public string Name { get; private set; } = null!;
        public List<Job> Jobs { get; private set; } = new List<Job>();
        public User User { get; init; } = null!;
        public Guid UserId { get; init; }
        public MetaData MetaData { get; private set; } = null!;

        protected Employer() { }
        private Employer(string name, User user, string email)
        {
            Id = Guid.NewGuid();
            Name = name;
            User = user;
            UserId = User.Id;
            MetaData = new MetaData();
        }

        public static Result<Employer> Create(string name, string email)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Result<Employer>.Failure(NameErrors.EmployerNameIsEmpty);

            var userResult = User.Create(email, name, UserType.Employer);
            if (!userResult.IsSuccess)
                return Result<Employer>.Failure(userResult.Error);

            return Result<Employer>.Success(new Employer(name, userResult.Value, email));
        }

        public Result SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Result.Failure(NameErrors.EmployerNameIsEmpty);

            return Result.Success();
        }

        public void CreateJob(Job job) => Jobs.Add(job);
    }
}

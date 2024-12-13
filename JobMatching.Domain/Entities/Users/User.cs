using JobMatching.Common.Results;
using JobMatching.Domain.BaseClasses;
using JobMatching.Domain.Enums;
using JobMatching.Domain.Errors;

namespace JobMatching.Domain.Entities.Users
{
    public class User : AuditableEntityBase
    {
        public string Name { get; private set; } = null!;
        public string Email { get; private set; } = null!;
        public UserType UserType { get; private set; }

        protected User() { }
        private User(string name, string email, UserType userType) 
        {
            base.Id = Guid.NewGuid();
            Name = name;
            Email = email;
            UserType = userType;
        }

        public static Result<User> CreateUserAsCandidate (string name, string email)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Result<User>.Failure(UserErrors.InvalidName);

            if (string.IsNullOrWhiteSpace(email))
                return Result<User>.Failure(UserErrors.InvalidEmail);

            return Result<User>.Success(new User(name, email, UserType.Candidate));
        }

        public static Result<User> CreateUserAsEmployer(string name, string email)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Result<User>.Failure(UserErrors.InvalidName);

            if (string.IsNullOrWhiteSpace(email))
                return Result<User>.Failure(UserErrors.InvalidEmail);

            return Result<User>.Success(new User(name, email, UserType.Employer));
        }
    }
}

using JobMatching.Common.Results;
using JobMatching.Domain.Enums;

namespace JobMatching.Domain.Entities.User
{
    public class User : DomainEntityBase
    {
        public string Name { get; } = string.Empty;
        public string Email { get; } = string.Empty;
        public UserType UserType { get; }

        private User(string id, string name, string email, UserType userType)
        {
            base.Id = Guid.Parse(id);
            Name = name;
            Email = email;
            UserType = userType;
        }

        public static Result<User> CreateCandidate(string id, string name, string email)
        {
            if (string.IsNullOrWhiteSpace(id) || Guid.Parse(id) == Guid.Empty)
                return Result<User>.Failure(new Error("Invalid user id."));

            if (string.IsNullOrWhiteSpace(name))
                return Result<User>.Failure(new Error("Name can't be empty."));

            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@")) 
                return Result<User>.Failure(new Error("Invalid email."));

            return Result<User>.Success(new User(id, name, email, UserType.Candidate));
        }

        public static Result<User> CreateEmployer(string id, string employerName, string email)
        {
            if (string.IsNullOrWhiteSpace(id) || Guid.Parse(id) == Guid.Empty)
                return Result<User>.Failure(new Error("Invalid user id."));

            if (string.IsNullOrWhiteSpace(employerName))
                return Result<User>.Failure(new Error("Name can't be empty."));

            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                return Result<User>.Failure(new Error("Invalid email."));

            return Result<User>.Success(new User(id, employerName, email, UserType.Employer));
        }
    }
}

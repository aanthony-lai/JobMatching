using JobMatching.Common.Results;
using JobMatching.Domain.Domain.Candidate.Entities;

namespace JobMatching.Domain.Entities.User
{
    public class User
    {
        public string Id { get; } = string.Empty;
        public Name Name { get; }
        public string EmployerName { get; } = string.Empty;
        public string Email { get; } = string.Empty;
        public UserType UserType { get; }

        private User(
            string id,
            Name name,
            string email,
            UserType userType = UserType.Candidate)
        {
            Id = id;
            Name = name;
            Email = email;
            UserType = userType;
        }

        private User(
            string id,
            string employerName,
            string email,
            UserType userType = UserType.Employer)
        {
            Id = id;
            EmployerName = employerName;
            Email = email;
            UserType = userType;
        }

        public static Result<User> CreateCandidate(
            string id,
            string firstName,
            string lastName,
            string email)
        {
            var nameResult = Name.Create(firstName, lastName);

            if (string.IsNullOrWhiteSpace(id) || Guid.Parse(id) == Guid.Empty)
                return Result<User>.Failure(new Error("Invalid user id."));

            if (!nameResult.IsSuccess)
                return Result<User>.Failure(nameResult.Error);

            if (string.IsNullOrWhiteSpace(email))
                return Result<User>.Failure(new Error("Invalid email."));

            return Result<User>.Success(new User(id, nameResult.Value, email));
        }

        public static Result<User> CreateEmployer(
            string id,
            string employerName,
            string email)
        {
            if (string.IsNullOrWhiteSpace(id) || Guid.Parse(id) == Guid.Empty)
                return Result<User>.Failure(new Error("Invalid user id."));

            if (string.IsNullOrWhiteSpace(employerName))
                return Result<User>.Failure(new Error("Employer name can't be empty."));

            if (string.IsNullOrWhiteSpace(email))
                return Result<User>.Failure(new Error("Invalid email."));

            return Result<User>.Success(new User(id, employerName, email));
        }

    }
}

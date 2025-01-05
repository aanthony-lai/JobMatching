using JobMatching.Common.Results;
using JobMatching.Domain.Entities.Candidate;
using JobMatching.Domain.Errors;

namespace JobMatching.Domain.Entities.User
{
    public class DomainUser
    {
        public string Id { get; } = string.Empty;
        public Name Name { get; } 
        public string EmployerName { get; } = string.Empty;
        public string Email { get; } = string.Empty;
        public UserType UserType { get; }

        private DomainUser(
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

        private DomainUser(
            string id, 
            string employerName, 
            string email, 
            UserType userType = UserType.Employer)
        {
            Id = Id;
            EmployerName = employerName;
            Email = email;
            UserType = userType;
        }

        public static Result<DomainUser> CreateCandidate(
            string id, 
            string firstName, 
            string lastName, 
            string email)
        {
            var nameResult = Name.Create(firstName, lastName);

            if (string.IsNullOrWhiteSpace(id) || Guid.Parse(id) == Guid.Empty)
                return Result<DomainUser>.Failure(new Error("Invalid user id."));

            if (!nameResult.IsSuccess)
                return Result<DomainUser>.Failure(nameResult.Error);

            if (string.IsNullOrWhiteSpace(email))
                return Result<DomainUser>.Failure(new Error("Invalid email."));

            return Result<DomainUser>.Success(new DomainUser(id, nameResult.Value, email));
        }

        public static Result<DomainUser> CreateEmployer(
            string id,
            string employerName,
            string email)
        {
            if (string.IsNullOrWhiteSpace(id) || Guid.Parse(id) == Guid.Empty)
                return Result<DomainUser>.Failure(new Error("Invalid user id."));

            if (string.IsNullOrWhiteSpace(employerName))
                return Result<DomainUser>.Failure(new Error("Employer name can't be empty."));

            if (string.IsNullOrWhiteSpace(email))
                return Result<DomainUser>.Failure(new Error("Invalid email."));

            return Result<DomainUser>.Success(new DomainUser(id, employerName, email));
        }

    }
}

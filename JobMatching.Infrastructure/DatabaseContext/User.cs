using JobMatching.Common.Results;
using JobMatching.Domain.Authentication.Registration;
using JobMatching.Domain.Entities.User;
using Microsoft.AspNetCore.Identity;

namespace JobMatching.Infrastructure.DatabaseContext
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; } = string.Empty;
        public string? LasName { get; set; } = string.Empty;
        public string? EmployerName { get; set; } = string.Empty;
        public UserType UserType { get; set; }

        protected User() : base() { }

        private User(
            string email, 
            string firstName, 
            string lastName)
        {
            base.Email = email;
            base.UserName = email;
            FirstName = firstName;
            LasName = lastName;
            UserType = UserType.Candidate;
        }

        private User(
            string email, 
            string employerName)
        {
            base.Email = email;
            base.UserName = email;
            EmployerName = employerName;
            UserType = UserType.Employer;
        }

        public static Result<User> CreateCandidateType(RegisterUserModel registerUserModel)
        {
            if (string.IsNullOrWhiteSpace(registerUserModel.FirstName) ||
                string.IsNullOrWhiteSpace(registerUserModel.LastName))
                return Result<User>.Failure(new Error("First and last name can't be empty."));

            if (string.IsNullOrWhiteSpace(registerUserModel.Email) ||
                !registerUserModel.Email.Contains("@"))
                return Result<User>.Failure(new Error("Invalid email address."));

            var user = new User(
                registerUserModel.Email, 
                registerUserModel.FirstName, 
                registerUserModel.LastName);

            return Result<User>.Success(user);
        }

        public static Result<User> CreateEmployerType(RegisterUserModel registerUserModel)
        {
            if (string.IsNullOrWhiteSpace(registerUserModel.EmployerName))
                Result<User>.Failure(new Error("Employer can't be empty."));

            if (string.IsNullOrWhiteSpace(registerUserModel.Email) ||
                !registerUserModel.Email.Contains("@"))
                return Result<User>.Failure(new Error("Invalid email address."));

            var user = new User(registerUserModel.Email, registerUserModel.EmployerName);

            return Result<User>.Success(user);
        }
    }
}

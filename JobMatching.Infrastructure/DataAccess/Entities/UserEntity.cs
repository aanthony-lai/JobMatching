using JobMatching.Common.Results;
using JobMatching.Domain.Authentication.Registration;
using JobMatching.Domain.Entities.User;
using Microsoft.AspNetCore.Identity;

namespace JobMatching.Infrastructure.DataAccess.Entities
{
    public class UserEntity : IdentityUser
    {
        public string? FirstName { get; set; } = string.Empty;
        public string? LasName { get; set; } = string.Empty;
        public string? EmployerName { get; set; } = string.Empty;
        public UserType UserType { get; set; }

        protected UserEntity() : base() { }

        private UserEntity(
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

        private UserEntity(
            string email,
            string employerName)
        {
            base.Email = email;
            base.UserName = email;
            EmployerName = employerName;
            UserType = UserType.Employer;
        }

        public static Result<UserEntity> CreateCandidate(RegisterUserModel registerUserModel)
        {
            if (string.IsNullOrWhiteSpace(registerUserModel.FirstName) ||
                string.IsNullOrWhiteSpace(registerUserModel.LastName))
                return Result<UserEntity>.Failure(new Error("First and last name can't be empty."));

            if (string.IsNullOrWhiteSpace(registerUserModel.Email) ||
                !registerUserModel.Email.Contains("@"))
                return Result<UserEntity>.Failure(new Error("Invalid email address."));

            var user = new UserEntity(
                registerUserModel.Email,
                registerUserModel.FirstName,
                registerUserModel.LastName);

            return Result<UserEntity>.Success(user);
        }

        public static Result<UserEntity> CreateEmployer(RegisterUserModel registerUserModel)
        {
            if (string.IsNullOrWhiteSpace(registerUserModel.EmployerName))
                Result<UserEntity>.Failure(new Error("Employer can't be empty."));

            if (string.IsNullOrWhiteSpace(registerUserModel.Email) ||
                !registerUserModel.Email.Contains("@"))
                return Result<UserEntity>.Failure(new Error("Invalid email address."));

            var user = new UserEntity(registerUserModel.Email, registerUserModel.EmployerName);

            return Result<UserEntity>.Success(user);
        }
    }
}

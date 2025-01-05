using JobMatching.Common.Results;
using JobMatching.Domain.Authentication;
using JobMatching.Domain.Authentication.Registration;
using Microsoft.AspNetCore.Identity;

namespace JobMatching.Infrastructure.Authentication
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LasName { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string EmployerName { get; set; } = string.Empty;
        public UserType UserType { get; set; }

        protected User(): base() { }
        private User(RegisterUserModel registerUserModel)
        {
            base.UserName = registerUserModel.UserName;
            FirstName = registerUserModel.FirstName;
            LasName = registerUserModel.LasName;
            FullName = $"{FirstName} {LasName}";
            EmployerName = registerUserModel.EmployerName;
            base.Email = registerUserModel.Email;
            UserType = (UserType)registerUserModel.UserType;
        }

        public static Result<User> Create(RegisterUserModel registerUserModel)
        {
            if (string.IsNullOrWhiteSpace(registerUserModel.UserName))
                return Result<User>.Failure(new Error("Invalid user name."));
            
            if (string.IsNullOrWhiteSpace(registerUserModel.FirstName))
                return Result<User>.Failure(new Error("Invalid first name."));

            if (string.IsNullOrWhiteSpace(registerUserModel.LasName))
                return Result<User>.Failure(new Error("Invalid last name."));

            if (string.IsNullOrWhiteSpace(registerUserModel.Email) ||
                !registerUserModel.Email.Contains("@"))
                return Result<User>.Failure(new Error("Invalid email address."));

            var user = new User(registerUserModel);

            return Result<User>.Success(user);
        }
    }
}

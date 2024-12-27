using JobMatching.Common.Results;
using JobMatching.Domain.Authentication;
using Microsoft.AspNetCore.Identity;

namespace JobMatching.Infrastructure.Authentication
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LasName { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;

        protected ApplicationUser(): base() { }
        private ApplicationUser(RegisterUserModel registerUserModel)
        {
            base.UserName = registerUserModel.UserName;
            FirstName = registerUserModel.FirstName;
            LasName = registerUserModel.LasName;
            FullName = $"{FirstName} {LasName}";
            base.Email = registerUserModel.Email;
        }

        public static Result<ApplicationUser> Create(RegisterUserModel registerUserModel)
        {
            if (string.IsNullOrWhiteSpace(registerUserModel.UserName))
                return Result<ApplicationUser>.Failure(new Error("Invalid user name."));
            
            if (string.IsNullOrWhiteSpace(registerUserModel.FirstName))
                return Result<ApplicationUser>.Failure(new Error("Invalid first name."));

            if (string.IsNullOrWhiteSpace(registerUserModel.LasName))
                return Result<ApplicationUser>.Failure(new Error("Invalid last name."));

            if (string.IsNullOrWhiteSpace(registerUserModel.Email) ||
                !registerUserModel.Email.Contains("@"))
                return Result<ApplicationUser>.Failure(new Error("Invalid email address."));

            var user = new ApplicationUser(registerUserModel);

            return Result<ApplicationUser>.Success(user);
        }
    }
}

using JobMatching.Common.Results;
using JobMatching.Domain.Authentication;
using JobMatching.Domain.Authentication.Login;
using JobMatching.Domain.Entities.User;
using JobMatching.Infrastructure.DatabaseContext;
using Microsoft.AspNetCore.Identity;

namespace JobMatching.Infrastructure.Authentication
{
    public sealed class LoginService(
        UserManager<User> userManager,
        ITokenProvider tokenProvider) : ILoginService
    {
        public async Task<Result<string>> LoginAsync(LoginUserModel loginUserModel)
        {
            var applicationUser = await userManager.FindByNameAsync(loginUserModel.UserName);

            if (applicationUser == null ||
                !await userManager.CheckPasswordAsync(applicationUser, loginUserModel.Password))
            {
                return Result<string>.Failure(new Error("Invalid credentials"));
            }

            var domainUserResult = applicationUser.UserType == UserType.Candidate
                ? DomainUser.CreateCandidate(
                    applicationUser.Id,
                    applicationUser.FirstName,
                    applicationUser.LasName,
                    applicationUser.Email!)
                : DomainUser.CreateEmployer(
                    applicationUser.Id, 
                    applicationUser.EmployerName, 
                    applicationUser.Email!);

            return tokenProvider.Create(domainUserResult.Value);
        }
    }
}

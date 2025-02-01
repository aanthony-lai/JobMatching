using JobMatching.Common.Results;
using JobMatching.Domain.Authentication;
using JobMatching.Domain.Authentication.Login;
using JobMatching.Domain.Entities.User;
using JobMatching.Domain.Enums;
using JobMatching.Infrastructure.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;

namespace JobMatching.Infrastructure.Authentication
{
    public sealed class LoginService(
        UserManager<UserEntity> userManager,
        ITokenProvider tokenProvider) : ILoginService
    {
        public async Task<Result<string>> LoginAsync(LoginUserModel loginUserModel)
        {
            var user = await userManager.FindByNameAsync(loginUserModel.UserName);

            if (user == null || !await userManager.CheckPasswordAsync(user, loginUserModel.Password))
                return Result<string>.Failure(new Error("Invalid credentials"));

            var domainUser = user.UserType == UserType.Candidate
                ? User.CreateCandidate(
                    user.Id,
                    $"{user.FirstName} {user.LasName}",
                    user.Email!)
                : User.CreateEmployer(
                    user.Id, 
                    user.EmployerName, 
                    user.Email!);

            return tokenProvider.Create(domainUser.Value);
        }
    }
}

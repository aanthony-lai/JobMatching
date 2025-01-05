using JobMatching.Common.Results;
using JobMatching.Domain.Authentication;
using JobMatching.Domain.Authentication.Login;
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

            return tokenProvider.Create(new DomainUser
            {
                Id = applicationUser.Id!,
                FirstName = applicationUser.FirstName,
                LasName = applicationUser.LasName,
                Email = applicationUser.Email ?? string.Empty
            });
        }
    }
}

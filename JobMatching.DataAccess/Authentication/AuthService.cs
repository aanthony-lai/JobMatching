using JobMatching.Common.Results;
using JobMatching.Domain.Authentication;
using Microsoft.AspNetCore.Identity;

namespace JobMatching.Infrastructure.Authentication
{
    public sealed class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ITokenProvider _tokenProvider;
        
        public AuthService(
            UserManager<IdentityUser> userManager,
            ITokenProvider tokenProvider) 
        {
            _userManager = userManager;
            _tokenProvider = tokenProvider;
        }

        public async Task<Result<string>> LoginAsync(LoginUserModel loginUserModel)
        {
            var user = await _userManager.FindByNameAsync(loginUserModel.UserName);
            if (user == null || !await _userManager.CheckPasswordAsync(user, loginUserModel.Password))
            {
                return Result<string>.Failure(new Error("Invalid credentials"));
            }

            return _tokenProvider.Create(loginUserModel); 
        }
        
        public async Task<Result> RegisterAsync(RegisterUserModel registerUserModel)
        {
            var user = new IdentityUser()
            {
                UserName = registerUserModel.Name, 
                Email = registerUserModel.Email
            };
            var result = await _userManager.CreateAsync(user, registerUserModel.Password);

            return !result.Succeeded 
                ? Result.Failure(new Error("An error ocurrecd, while trying to create the user.")) 
                : Result.Success();
        }
    }
}

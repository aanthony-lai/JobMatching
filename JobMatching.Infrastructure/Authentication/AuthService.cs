using JobMatching.Common.Results;
using JobMatching.Domain.Authentication;
using Microsoft.AspNetCore.Identity;

namespace JobMatching.Infrastructure.Authentication
{
    public sealed class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenProvider _tokenProvider;
        
        public AuthService(
            UserManager<ApplicationUser> userManager,
            ITokenProvider tokenProvider) 
        {
            _userManager = userManager;
            _tokenProvider = tokenProvider;
        }

        public async Task<Result<string>> LoginAsync(LoginUserModel loginUserModel)
        {
            var applicationUser = await _userManager.FindByNameAsync(loginUserModel.UserName);

            if (applicationUser == null || 
                !await _userManager.CheckPasswordAsync(applicationUser, loginUserModel.Password))
            {
                return Result<string>.Failure(new Error("Invalid credentials"));
            }

            return _tokenProvider.Create(new User
            {
                Id = applicationUser.Id!,
                FirstName = applicationUser.FirstName,
                LasName = applicationUser.LasName,
                Email = applicationUser.Email ?? string.Empty
            }); 
        }
        
        public async Task<Result> RegisterAsync(RegisterUserModel registerUserModel)
        {
            var existingUser = await _userManager.FindByEmailAsync(registerUserModel.Email);

            if (existingUser != null)
                return Result.Failure(new Error("Email is already in use."));

            var createUserResult = ApplicationUser.Create(registerUserModel);

            if (!createUserResult.IsSuccess)
                return Result.Failure(createUserResult.Error);

            var result = await _userManager.CreateAsync(createUserResult.Value, registerUserModel.Password);

            return !result.Succeeded 
                ? Result.Failure(new Error("An error ocurrecd, while trying to create the user.")) 
                : Result.Success();
        }
    }
}

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

        public async Task<Result<string>> HandleAsync(DomainUser domainUser)
        {
            var user = await _userManager.FindByNameAsync(domainUser.Name);
            if (user == null || !await _userManager.CheckPasswordAsync(user, domainUser.Password))
            {
                return Result<string>.Failure(new Error("Invalid credentials"));
            }

            return _tokenProvider.Create(domainUser); 
        }
    }
}

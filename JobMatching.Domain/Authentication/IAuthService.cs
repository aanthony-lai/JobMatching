using JobMatching.Common.Results;

namespace JobMatching.Domain.Authentication
{
    public interface IAuthService
    {
        Task<Result<string>> LoginAsync(LoginUserModel loginUserModel);
        Task<Result> RegisterAsync(RegisterUserModel registerUserModel);
    }
}

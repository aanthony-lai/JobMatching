using JobMatching.Common.Results;

namespace JobMatching.Domain.Authentication.Login
{
    public interface ILoginService
    {
        Task<Result<string>> LoginAsync(LoginUserModel loginUserModel);
    }
}

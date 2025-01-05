using JobMatching.Common.Results;

namespace JobMatching.Domain.Authentication.Registration
{
    public interface IRegistrationService
    {
        Task<Result> RegisterAsync(RegisterUserModel registerUserModel);
    }
}

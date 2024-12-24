using JobMatching.Common.Results;

namespace JobMatching.Domain.Authentication
{
    public interface IAuthService
    {
        Task<Result<string>> HandleAsync(DomainUser domainUser);
    }
}

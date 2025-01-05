using JobMatching.Common.Results;
using JobMatching.Domain.Authentication;

namespace JobMatching.Application.Authentication.Register
{
    public interface IUserProfileCreator
    {
        Task<Result> CreateProfileAsync(DomainUser domainUser);
    }
}

using JobMatching.Common.Results;
using JobMatching.Domain.Entities.User;

namespace JobMatching.Application.Authentication.ProfileCreation
{
    public interface IUserProfileCreator
    {
        Task<Result> CreateAsync(DomainUser domainUser);
    }
}

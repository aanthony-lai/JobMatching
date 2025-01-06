using JobMatching.Application.Candidates;
using JobMatching.Application.Interfaces.Services;
using JobMatching.Common.Results;
using JobMatching.Domain.Entities.User;

namespace JobMatching.Application.Authentication.Register
{
    public class UserProfileCreator(
        ICandidateService candidateService,
        IEmployerService employerService) : IUserProfileCreator
    {
        public async Task<Result> CreateAsync(DomainUser domainUser)
        {
            return domainUser.UserType == UserType.Candidate
                ? await candidateService.CreateAsync(domainUser)
                : await employerService.CreateAsync(domainUser);
        }
    }
}

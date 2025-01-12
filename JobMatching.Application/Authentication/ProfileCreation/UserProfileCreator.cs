using JobMatching.Application.CandidateServices;
using JobMatching.Application.EmployerServices;
using JobMatching.Common.Results;
using JobMatching.Domain.Entities.User;

namespace JobMatching.Application.Authentication.ProfileCreation
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

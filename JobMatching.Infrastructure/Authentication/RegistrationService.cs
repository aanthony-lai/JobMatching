using JobMatching.Application.Authentication.Register;
using JobMatching.Common.Results;
using JobMatching.Domain.Authentication.Registration;
using JobMatching.Domain.Entities.User;
using JobMatching.Infrastructure.DatabaseContext;
using Microsoft.AspNetCore.Identity;

namespace JobMatching.Infrastructure.Authentication
{
    //Needs re-factoring
    public sealed class RegistrationService(
        UserManager<User> userManager,
        IUserProfileCreator createUserProfileService) : IRegistrationService
    {
        public async Task<Result> RegisterAsync(RegisterUserModel registerCandidateModel)
        {
            if (!await ValidateEmailNotAlreadyExistAsync(registerCandidateModel.Email))
                return Result.Failure(new Error("Email is already in use."));

            var createUserResult = User.CreateCandidateType(registerCandidateModel);

            if (!createUserResult.IsSuccess)
                return Result.Failure(createUserResult.Error);

            var registerUserResult = await userManager.CreateAsync(
                createUserResult.Value, registerCandidateModel.Password);

            if (registerUserResult.Succeeded)
            {
                var result = await CreateUserProfile(createUserResult.Value);
                return result.IsSuccess
                    ? Result.Success()
                    : Result.Failure(result.Error);
            }

            return Result.Failure(new Error("An error occurred, while trying to create the user."));
        }

        private async Task<bool> ValidateEmailNotAlreadyExistAsync(string email) =>
            await userManager.FindByEmailAsync(email) == null;

        private async Task RollBackUserCreation(User user) =>
            await userManager.DeleteAsync(user);

        private async Task<Result> CreateUserProfile(User user)
        {
            Result<DomainUser> domainUser = user.UserType == UserType.Candidate 
                ? DomainUser.CreateCandidate(
                    user.Id,
                    user.FirstName!,
                    user.LasName!,
                    user.Email!)
                : DomainUser.CreateEmployer(
                    user.Id,
                    user.EmployerName,
                    user.Email!);

            if (!domainUser.IsSuccess)
                return Result.Failure(domainUser.Error);

            var createUserProfileResult = await createUserProfileService
                .CreateProfileAsync(domainUser.Value);

            if (!createUserProfileResult.IsSuccess)
            {
                await RollBackUserCreation(user);
                return Result.Failure(createUserProfileResult.Error);
            }

            return Result.Success();
        } 
    }
}
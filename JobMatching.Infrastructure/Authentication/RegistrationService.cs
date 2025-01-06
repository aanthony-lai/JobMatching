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
        IUserProfileCreator userProfileCreator) : IRegistrationService
    {
        public async Task<Result> RegisterAsync(RegisterUserModel registerUserModel)
        {
            if (!await ValidateEmailNotAlreadyExistAsync(registerUserModel.Email))
                return Result.Failure(new Error("Email is already in use."));

            var createUserResult = registerUserModel.UserType == UserType.Candidate
                ? User.CreateCandidate(registerUserModel)
                : User.CreateEmployer(registerUserModel);

            if (!createUserResult.IsSuccess)
                return Result.Failure(createUserResult.Error);

            var registerUserResult = await userManager.CreateAsync(
                createUserResult.Value, registerUserModel.Password);

            if (!registerUserResult.Succeeded)
                return Result.Failure(new Error("An error occurred, while trying to create the user."));
            
            var result = await CreateUserProfile(createUserResult.Value);

            return result.IsSuccess
                ? Result.Success()
                : Result.Failure(result.Error);
        }

        private async Task<bool> ValidateEmailNotAlreadyExistAsync(string email) =>
            await userManager.FindByEmailAsync(email) == null;

        private async Task RollBackUserCreation(User user) =>
            await userManager.DeleteAsync(user);

        private async Task<Result> CreateUserProfile(User user)
        {
            var domainUserResult = user.UserType == UserType.Candidate 
                ? DomainUser.CreateCandidate(
                    user.Id,
                    user.FirstName!,
                    user.LasName!,
                    user.Email!)
                : DomainUser.CreateEmployer(
                    user.Id,
                    user.EmployerName,
                    user.Email!);

            if (!domainUserResult.IsSuccess)
                return Result.Failure(domainUserResult.Error);

            var createUserProfileResult = await userProfileCreator
                .CreateAsync(domainUserResult.Value);

            if (createUserProfileResult.IsSuccess) return Result.Success();
           
            await RollBackUserCreation(user);
            
            return Result.Failure(createUserProfileResult.Error);
        } 
    }
}
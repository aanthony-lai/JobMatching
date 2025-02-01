using JobMatching.Application.Authentication.ProfileCreation;
using JobMatching.Common.Results;
using JobMatching.Domain.Authentication.Registration;
using JobMatching.Domain.Entities.User;
using JobMatching.Domain.Enums;
using JobMatching.Infrastructure.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;

namespace JobMatching.Infrastructure.Authentication
{
    public sealed class RegistrationService(UserManager<UserEntity> userManager, IUserProfileCreator userProfileCreator) : IRegistrationService
    {
        public async Task<Result> RegisterAsync(RegisterUserModel registerModel)
        {
            if (await userManager.FindByEmailAsync(registerModel.Email) != null)
                return Result.Failure(new Error("Email is already in use."));

            var user = CreateUserEntity(registerModel);

            var result = await userManager.CreateAsync(user, registerModel.Password);

            if (!result.Succeeded)
                return Result.Failure(new Error("An error occurred, while trying to create the user."));

            var userProfile = await CreateUserProfile(user);

            return userProfile.IsSuccess
                ? Result.Success()
                : Result.Failure(userProfile.Error);
        }

        private async Task RollBackUserCreation(UserEntity user) => await userManager.DeleteAsync(user);

        private UserEntity CreateUserEntity(RegisterUserModel registerModel)
        {
            return registerModel.UserType == UserType.Candidate
                ? new UserEntity {
                    FirstName = registerModel.FirstName,
                    LasName = registerModel.LastName,
                    UserType = registerModel.UserType
                }
                : new UserEntity {
                    EmployerName = registerModel.EmployerName,
                    UserType = registerModel.UserType
                };
        }

        private async Task<Result> CreateUserProfile(UserEntity user)
        {
            var domainUser = user.UserType == UserType.Candidate
                ? User.CreateCandidate(
                    user.Id,
                    $"{user.FirstName} {user.LasName}",
                    user.Email!)
                : User.CreateEmployer(
                    user.Id,
                    user.EmployerName,
                    user.Email!);

            if (!domainUser.IsSuccess)
                return Result.Failure(domainUser.Error);

            var userProfile = await userProfileCreator
                .CreateAsync(domainUser.Value);

            if (!userProfile.IsSuccess)
            {
                await RollBackUserCreation(user);
                return Result.Failure(userProfile.Error);
            } 
            
            return Result.Success();
        }
    }
}
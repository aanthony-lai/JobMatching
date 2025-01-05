using JobMatching.Application.Authentication.Register;
using JobMatching.Common.Results;
using JobMatching.Domain.Authentication;
using JobMatching.Domain.Authentication.Registration;
using Microsoft.AspNetCore.Identity;

namespace JobMatching.Infrastructure.Authentication
{
    public sealed class RegistrationService(
        UserManager<User> userManager,
        IUserProfileCreator createUserProfileService) : IRegistrationService
    {
        public async Task<Result> RegisterAsync(RegisterUserModel registerUserModel)
        {
            if (!await ValidateEmailNotAlreadyExistAsync(registerUserModel.Email))
                return Result.Failure(new Error("Email is already in use."));

            var createUserResult = User.Create(registerUserModel);

            if (!createUserResult.IsSuccess)
                return Result.Failure(createUserResult.Error);

            var registerUserResult = await userManager.CreateAsync(createUserResult.Value, registerUserModel.Password);

            if (registerUserResult.Succeeded)
            {
                var createUserProfileResult = await createUserProfileService.CreateProfileAsync(
                    new DomainUser()
                    {
                        Id = createUserResult.Value.Id,
                        FirstName = createUserResult.Value.FirstName,
                        LasName = createUserResult.Value.LasName,
                        EmployerName = createUserResult.Value.EmployerName,
                        Email = createUserResult.Value.Email!,
                        UserType = createUserResult.Value.UserType,
                    });

                if (!createUserProfileResult.IsSuccess)
                {
                    await RollBackUserCreation(createUserResult.Value);
                    return Result.Failure(createUserProfileResult.Error);
                }
            }
            else
            {
                return Result.Failure(new Error("An error occurred, while trying to create the user."));
            }

            return Result.Success();
        }

        private async Task<bool> ValidateEmailNotAlreadyExistAsync(string email) =>
            await userManager.FindByEmailAsync(email) == null;
        
        private async Task RollBackUserCreation(User user) => 
            await userManager.DeleteAsync(user);
    }
}
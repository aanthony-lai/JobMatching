using JobMatching.Common.Results;
using JobMatching.Domain.Authentication.Registration;
using MediatR;

namespace JobMatching.Application.Authentication.Register;

public class RegisterHandler(
    IRegistrationService registerService) : IRequestHandler<RegisterRequest, Result>
{
    public async Task<Result> Handle(RegisterRequest request, CancellationToken cancellationToken)
    {
        var registerResult = await registerService.RegisterAsync(request.RegisterUserModel);

        return registerResult.IsSuccess
            ? Result.Success()
            : Result.Failure(registerResult.Error);
    }
}
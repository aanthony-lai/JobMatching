using JobMatching.Common.Results;
using JobMatching.Domain.Authentication;
using MediatR;

namespace JobMatching.Application.Authentication.Register;

public class RegisterHandler: IRequestHandler<RegisterRequest, Result>
{
    private readonly IAuthService _authService;

    public RegisterHandler(IAuthService authService)
    {
        _authService = authService;
    }    
    
    public async Task<Result> Handle(RegisterRequest request, CancellationToken cancellationToken)
    {
        var registerResult = await _authService.RegisterAsync(request.RegisterUserModel);

        return registerResult.IsSuccess
            ? Result.Success()
            : Result.Failure(registerResult.Error);
    }
}
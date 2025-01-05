using JobMatching.Common.Results;
using JobMatching.Domain.Authentication.Login;
using MediatR;

namespace JobMatching.Application.Authentication.Login
{
    public sealed class LoginHandler : IRequestHandler<LoginRequest, Result<string>>
    {
        private readonly ILoginService _authService;

        public LoginHandler(ILoginService authService)
        {
            _authService = authService;
        }

        public async Task<Result<string>> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var authResult = await _authService.LoginAsync(request.UserModel);

            if (!authResult.IsSuccess)
                return authResult;

            return Result<string>.Success(authResult.Value);
        }
    }
}

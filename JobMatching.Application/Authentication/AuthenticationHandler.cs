using JobMatching.Common.Results;
using JobMatching.Domain.Authentication;
using MediatR;

namespace JobMatching.Application.Authentication
{
    public sealed class AuthenticationHandler : IRequestHandler<AuthenticationRequest, Result<string>>
    {
        private readonly IAuthService _authService;

        public AuthenticationHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<Result<string>> Handle(AuthenticationRequest request, CancellationToken cancellationToken)
        {
            var authResult = await _authService.HandleAsync(request.User);

            if (!authResult.IsSuccess)
                return authResult;

            return Result<string>.Success(authResult.Value);
        }
    }
}

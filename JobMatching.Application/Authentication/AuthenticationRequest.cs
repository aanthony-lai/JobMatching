using JobMatching.Common.Results;
using JobMatching.Domain.Authentication;
using MediatR;

namespace JobMatching.Application.Authentication
{
    public sealed class AuthenticationRequest: IRequest<Result<string>>
    {
        public DomainUser User { get; } = null!;
        public AuthenticationRequest(DomainUser user)
        {
            User = user;
        }
    }
}

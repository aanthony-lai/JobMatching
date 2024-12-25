using JobMatching.Common.Results;
using JobMatching.Domain.Authentication;
using MediatR;

namespace JobMatching.Application.Authentication
{
    public sealed class LoginRequest: IRequest<Result<string>>
    {
        public DomainUser User { get; } = null!;
        public LoginRequest(DomainUser user)
        {
            User = user;
        }
    }
}

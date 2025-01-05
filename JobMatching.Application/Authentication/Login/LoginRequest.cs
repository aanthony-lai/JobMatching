using JobMatching.Common.Results;
using JobMatching.Domain.Authentication.Login;
using MediatR;

namespace JobMatching.Application.Authentication.Login
{
    public sealed class LoginRequest: IRequest<Result<string>>
    {
        public LoginUserModel UserModel { get; } = null!;
        public LoginRequest(LoginUserModel userModel)
        {
            UserModel = userModel;
        }
    }
}

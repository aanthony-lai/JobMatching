using JobMatching.Common.Results;
using JobMatching.Domain.Authentication.Registration;
using MediatR;

namespace JobMatching.Application.Authentication.Register;

public class RegisterRequest: IRequest<Result>
{
    public RegisterUserModel RegisterUserModel { get; }
    
    public RegisterRequest(RegisterUserModel registerUserModel)
    {
        RegisterUserModel = registerUserModel;
    }

}
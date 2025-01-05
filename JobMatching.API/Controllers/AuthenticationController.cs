using MediatR;
using Microsoft.AspNetCore.Mvc;
using JobMatching.Application.Authentication.Login;
using JobMatching.Application.Authentication.Register;
using JobMatching.Domain.Authentication.Login;
using JobMatching.Domain.Authentication.Registration;

namespace JobMatching.API.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController(IMediator mediator) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] LoginUserModel loginUserModel)
        {
            var loginResult = await mediator.Send(new LoginRequest(loginUserModel));

            return loginResult.Match<ActionResult>(
                success => Ok(loginResult.Value),
                failure => Unauthorized(loginResult.Error.ToString()));
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register([FromBody] RegisterUserModel registerUserModel)
        {
            var registerResult = await mediator.Send(new RegisterRequest(registerUserModel));

            return registerResult.Match<ActionResult>(
                Ok,
                failure => Unauthorized(registerResult.Error.ToString()));
        }
    }
}

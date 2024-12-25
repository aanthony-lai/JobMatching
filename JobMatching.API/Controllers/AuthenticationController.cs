using JobMatching.Application.Authentication;
using JobMatching.Domain.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobMatching.API.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] DomainUser domainUser)
        {
            var loginResult = await _mediator.Send(new LoginRequest(domainUser));

            return loginResult.Match<ActionResult>(
                success => Ok(loginResult.Value),
                failure => Unauthorized(loginResult.Error.ToString()));
        }

        [HttpPost("Register")]
        public async Task<ActionResult<string>> Register([FromBody] DomainUser domainUser)
        {
            var loginResult = await _mediator.Send(new LoginRequest(domainUser));

            return loginResult.Match<ActionResult>(
                success => Ok(loginResult.Value),
                failure => Unauthorized(loginResult.Error.ToString()));
        }
    }
}

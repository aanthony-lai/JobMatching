﻿using JobMatching.Domain.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using LoginRequest = JobMatching.Application.Authentication.Login.LoginRequest;
using RegisterRequest = JobMatching.Application.Authentication.Register.RegisterRequest;

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
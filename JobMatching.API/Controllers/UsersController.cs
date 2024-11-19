using JobMatching.Application.DTO;
using JobMatching.Application.Exceptions;
using JobMatching.Application.Interfaces;
using JobMatching.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace JobMatching.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService) 
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> GetUsersAsync()
        {
            return Ok(await _userService.GetUsersAsync());
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<UserDTO?>> GetUserById(Guid userId)
        {
            var user = await _userService.GetUserByIdAsync(userId);

            if (user is null)
                return NotFound($"User with the specified {userId} could not be found.");

            return Ok(user);
        }

		[HttpPost]
		public async Task<ActionResult> AddUserCompetence([FromBody] AddUserCompetenceDTO addUserCompetenceDto)
		{
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

			try
			{
                await _userService.AddUserCompetence(addUserCompetenceDto);
                return NoContent();
			}
			catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
		}
	}
}

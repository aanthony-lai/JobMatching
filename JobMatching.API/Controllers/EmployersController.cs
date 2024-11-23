using JobMatching.Application.DTO;
using JobMatching.Application.Interfaces;
using JobMatching.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace JobMatching.API.Controllers
{
	[Route("api/employers")]
	[ApiController]
	public class EmployersController : ControllerBase
	{
		private readonly IEmployerService _employerService;

		public EmployersController(IEmployerService employerService) 
		{
			_employerService = employerService;
		}

		[HttpGet]
		public async Task<ActionResult<List<EmployerDTO>>> GetEmployersAsync()
		{
			return await _employerService.GetEmployersAsync();
		}

		[HttpGet("{employerId}")]
		public async Task<ActionResult<EmployerDTO>> GetEmployerByIdAsync(Guid employerId)
		{
			if (employerId == Guid.Empty)
				return BadRequest("Invalid employer ID.");

			var employerDto = await _employerService.GetEmployerByIdAsync(employerId);

			return employerDto == null
				? NotFound($"User with the specified {employerId} could not be found.")
				: Ok(employerDto);
		}
	}
}

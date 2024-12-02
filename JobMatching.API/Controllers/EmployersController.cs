using JobMatching.Application.DTO.Employer;
using JobMatching.Application.Interfaces;
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
				? NotFound($"Employer with the specified {employerId} could not be found.")
				: Ok(employerDto);
		}

		[HttpPost]
		public async Task<ActionResult> CreateEmployerAsync([FromBody] CreateEmployerDTO createEmployerDto)
		{
			try
			{
				await _employerService.CreateEmployerAsync(createEmployerDto);
				return NoContent();
			}
			catch (Exception ex) 
			{
				return BadRequest(ex.Message);
			}
		}
	}
}

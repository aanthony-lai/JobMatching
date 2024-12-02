using JobMatching.Application.DTO.Applicant;
using JobMatching.Application.DTO.Employer;
using JobMatching.Application.Interfaces;
using JobMatching.Common.SystemMessages.JobMessages;
using Microsoft.AspNetCore.Mvc;

namespace JobMatching.API.Controllers
{
	[Route("api/employers")]
	[ApiController]
	public class EmployersController : ControllerBase
	{
		private readonly IEmployerService _employerService;
		private readonly IApplicantService _applicantService;

		public EmployersController(IEmployerService employerService,
			IApplicantService applicantService)
		{
			_employerService = employerService;
			_applicantService = applicantService;
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
	}
}

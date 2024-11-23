using JobMatching.Application.DTO;
using JobMatching.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JobMatching.API.Controllers
{
	[Route("api/job-applications")]
	[ApiController]
	public class JobApplicationsController : ControllerBase
	{
		private readonly IJobApplicationService _jobApplicationService;

		public JobApplicationsController(IJobApplicationService jobApplicationService)
		{
			_jobApplicationService = jobApplicationService;
		}

		[HttpGet]
		public async Task<ActionResult<List<JobApplicationDTO>>> GetJobApplicationsAsync()
		{
			return Ok(await _jobApplicationService.GetJobApplicationsAsync());
		}

		[HttpGet("{jobApplicationId}")]
		public async Task<ActionResult<JobApplicationDTO>> GetJobApplicationById(Guid jobApplicationId)
		{
			if (jobApplicationId == Guid.Empty)
				return BadRequest("Invalid job application ID.");

			var jobApplicationDto = await _jobApplicationService.GetJobApplicationByIdAsync(jobApplicationId);

			return jobApplicationDto == null
				? NotFound($"Job application with ID: {jobApplicationId} was not found.")
				: Ok(jobApplicationDto);
		}
	}
}

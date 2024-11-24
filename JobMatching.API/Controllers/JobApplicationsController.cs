using JobMatching.Application.DTO.JobApplication;
using JobMatching.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JobMatching.API.Controllers
{
	[Route("api/jobapplications/thisShouldBeRemovedLater")]
	[ApiController]
	public class JobApplicationsController : ControllerBase
	{
		private readonly IJobApplicationService _jobApplicationService;

		public JobApplicationsController(IJobApplicationService jobApplicationService)
		{
			_jobApplicationService = jobApplicationService;
		}

		//Should this endpoint be available?
		[HttpGet]
		public async Task<ActionResult<List<JobApplicationDTO>>> GetJobApplications()
		{
			return Ok(await _jobApplicationService.GetJobApplicationsAsync());
		}
	}
}

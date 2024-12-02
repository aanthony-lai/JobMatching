using JobMatching.Application.DTO.Job;
using JobMatching.Application.Interfaces;
using JobMatching.Common.SystemMessages.JobMessages;
using Microsoft.AspNetCore.Mvc;

namespace JobMatching.API.Controllers
{
    [Route("api/jobs")]
	[ApiController]
	public class JobsController : ControllerBase
	{
		private readonly IJobService _jobService;

		public JobsController(IJobService jobService)
		{
			_jobService = jobService;
		}

		[HttpGet("{employerId}")]
		public async Task<ActionResult<List<JobDTO>>> GetJobsByEmployerIdAsync(Guid employerId)
		{
			if (employerId == Guid.Empty)
				return BadRequest(JobMessages.InvalidJobId(employerId));

			var jobsDto = await _jobService.GetJobsByEmployerIdAsync(employerId);
			return Ok(jobsDto);
		}

		[HttpGet]
		public async Task<ActionResult<List<JobDTO>>> GetJobsAsync()
		{
			return Ok(await _jobService.GetJobsAsync());
		}
	}
}

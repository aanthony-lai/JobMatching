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

		[HttpGet("{jobId}")]
		public async Task<ActionResult<JobDTO>> GetJobByIdAsync(Guid jobId)
		{
			if (jobId == Guid.Empty)
				return BadRequest(JobMessages.InvalidJobId(jobId));

			var job = await _jobService.GetJobByIdAsync(jobId);

			return job is null
				? NotFound(JobMessages.JobNotFound(jobId))
				: Ok(job);
		}

		[HttpGet]
		public async Task<ActionResult<List<JobDTO>>> GetJobsAsync()
		{
			return Ok(await _jobService.GetJobsAsync());
		}
	}
}

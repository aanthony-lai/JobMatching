using JobMatching.Application.DTO;
using JobMatching.Application.Interfaces;
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
				return BadRequest($"Invalid job ID.");

			var jobDto = await _jobService.GetJobByIdAsync(jobId);

			return jobDto == null 
				? NotFound($"Job with job ID: {jobId} was not found.")
				: Ok(jobDto);
		}

		[HttpGet]
		public async Task<List<JobDTO>> GetJobsAsync()
		{
			return await _jobService.GetJobsAsync();
		}
	}
}

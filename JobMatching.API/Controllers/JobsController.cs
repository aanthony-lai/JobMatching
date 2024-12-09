using JobMatching.Application.DTO.Job;
using JobMatching.Application.Interfaces;
using JobMatching.Common.Exceptions;
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

		[HttpGet]
		public async Task<ActionResult<List<JobDTO>>> GetAllAsync()
		{
			return Ok(await _jobService.GetJobsAsync());
		}

		[HttpGet("{jobTitle}")]
		public async Task<ActionResult<List<JobDTO>>> GetByJobTitleAsync(string jobTitle)
		{
			if (string.IsNullOrWhiteSpace(jobTitle))
				return BadRequest(JobMessages.InvalidJobTitle(jobTitle));

			var jobsDto = await _jobService.GetByJobTitleAsync(jobTitle);
			return Ok(jobsDto);
		}

		[HttpPost]
		public async Task<ActionResult> CreateAsync([FromBody] CreateJobDTO createJobDto)
		{
			if (createJobDto.EmployerId == Guid.Empty)
				return BadRequest("Invalid employer ID.");

			try
			{
				await _jobService.PostJobAsync(createJobDto);
				return NoContent();
			}
			catch (ArgumentOutOfRangeException) 
			{
				return BadRequest("The upper salary range can't be lower than the lower salary range");
			}
			catch (Exception)
			{
				return StatusCode(500, "An error occured.");
			}

		}

		[HttpPost("{jobId}/competence")]
		public async Task<ActionResult> CreateCompetenceAsync([FromBody] AddJobCompetenceDTO addJobCompetenceDTO)
		{
			try
			{
                await _jobService.AddJobCompetence(addJobCompetenceDTO);
                return NoContent();
            }
			catch (EntityNotFoundException ex)
			{
				return BadRequest(ex.Message);
			}
			catch (EntityAlreadyExistException ex)
			{
				return BadRequest(ex.Message);
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}
		}
	}
}

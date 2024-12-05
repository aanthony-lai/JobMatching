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

		[HttpPost]
		public async Task<ActionResult> PostJobAsync([FromBody] CreateJobDTO createJobDto)
		{
			if (createJobDto.EmployerId == Guid.Empty)
				return BadRequest("Invalid employer ID.");

			try
			{
				await _jobService.PostJobAsync(createJobDto);
				return NoContent();
			}
			catch (ArgumentException ex) 
			{
				return BadRequest(ex.Message);
			}
			catch (Exception)
			{
				return StatusCode(500, "An error occured.");
			}

		}

		[HttpPost("competence")]
		public async Task<ActionResult> AddJobCompetenceAsync([FromBody] AddJobCompetenceDTO addJobCompetenceDTO)
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

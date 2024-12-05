using JobMatching.Application.DTO.JobApplication;
using JobMatching.Application.Interfaces;
using JobMatching.Common.Exceptions;
using JobMatching.Common.SystemMessages.CandidateMessages;
using Microsoft.AspNetCore.Mvc;

namespace JobMatching.API.Controllers
{
	[Route("api/jobapplications")]
	[ApiController]
	public class JobApplicationsController : ControllerBase
	{
		private readonly IJobApplicationService _jobApplicationService;
		private readonly ICandidateService _candidateService;

		public JobApplicationsController(
			IJobApplicationService jobApplicationService, 
			ICandidateService candidateService)
		{
			_jobApplicationService = jobApplicationService;
			_candidateService = candidateService;
		}

		//Should this endpoint be available?
		[HttpGet("shouldBeRemoved")]
		public async Task<ActionResult<List<JobApplicationDTO>>> GetJobApplications()
		{
			return Ok(await _jobApplicationService.GetJobApplicationsAsync());
		}

		[HttpGet("{candidateId}")]
		public async Task<ActionResult<List<JobApplicationDTO>>> GetJobApplicationsByCandidateId(Guid candidateId)
		{
			if (candidateId == Guid.Empty)
				return BadRequest(CandidateMessages.InvalidCandidateId(candidateId));

			if (!await _candidateService.CandidateExistsAsync(candidateId))
				return NotFound(CandidateMessages.CandidateNotFound(candidateId));

			return Ok(await _jobApplicationService.GetJobApplicationsByCandidateIdAsync(candidateId));
		}

		[HttpPost("jobapplications")]
		public async Task<ActionResult> CreateJobApplicationAsync([FromBody] CreateJobApplicationDTO createJobApplicationDTO)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			try
			{
                await _jobApplicationService.CreateJobApplicationAsync(createJobApplicationDTO);
                return NoContent();
            }
			catch (EntityAlreadyExistException ex)
			{
				return BadRequest(ex.Message);
			}
			catch (Exception)
			{
				return StatusCode(500, "An error occurred while trying to create the job application.");
			}
		}
	}
}

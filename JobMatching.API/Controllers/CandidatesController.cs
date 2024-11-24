using JobMatching.Application.DTO.Candidate;
using JobMatching.Application.DTO.JobApplication;
using JobMatching.Application.Interfaces;
using JobMatching.Common.SystemMessages.CandidateMessages;
using Microsoft.AspNetCore.Mvc;

namespace JobMatching.API.Controllers
{
	[Route("api/candidates")]
	[ApiController]
	public class CandidatesController : ControllerBase
	{
		private readonly ICandidateService _candidateService;
		private readonly IJobApplicationService _jobApplicationService;

		public CandidatesController(
			ICandidateService candidateService,
			IJobApplicationService jobApplicationService)
		{
			_candidateService = candidateService;
			_jobApplicationService = jobApplicationService;
		}

		//This one should probably be removed later.
		[HttpGet("shouldBeRemovedLater")]
		public async Task<ActionResult<List<CandidateDTO>>> GetCandidatesAsync()
		{
			return Ok(await _candidateService.GetCandidatesAsync());
		}

		[HttpGet("{candidateId}")]
		public async Task<ActionResult<CandidateDTO?>> GetCandidateById(Guid candidateId)
		{
			if (candidateId == Guid.Empty)
				return BadRequest(CandidateMessages.InvalidCandidateId(candidateId));

			var candidate = await _candidateService.GetCandidateByIdAsync(candidateId);

			return candidate is null
				? NotFound(CandidateMessages.CandidateNotFound(candidateId))
				: Ok(candidate);
		}

		[HttpGet("{candidateId}/jobapplications")]
		public async Task<ActionResult<List<JobApplicationDTO>>> GetJobApplicationsByCandidateId(Guid candidateId)
		{
			if (candidateId == Guid.Empty)
				return BadRequest(CandidateMessages.InvalidCandidateId(candidateId));

			if (!await _candidateService.CandidateExistsAsync(candidateId))
				return NotFound(CandidateMessages.CandidateNotFound(candidateId));

			return Ok(await _jobApplicationService.GetJobApplicationsByCandidateIdAsync(candidateId));
		}

		[HttpPost]
		public async Task<ActionResult> AddUserCompetence([FromBody] AddCandidateCompetenceDTO addCandidateCompetenceDto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			try
			{
				await _candidateService.AddCandidateCompetence(addCandidateCompetenceDto);
				return NoContent();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}

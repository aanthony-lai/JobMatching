using JobMatching.Application.DTO.Candidate;
using JobMatching.Application.Interfaces;
using JobMatching.Common.SystemMessages.CandidateMessages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobMatching.API.Controllers
{
	[Route("api/candidates")]
	[ApiController]
	public class CandidatesController : ControllerBase
	{
		private readonly ICandidateService _candidateService;

		public CandidatesController(
			ICandidateService candidateService)
		{
			_candidateService = candidateService;
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

		[HttpPost]
		public async Task<ActionResult> CreateCandidate([FromBody] CreateCandidateDTO createCandidateDto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			try
			{
				await _candidateService.CreateCandidateAsync(createCandidateDto);
				return NoContent();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("competences")]
		public async Task<ActionResult> AddCandidateCompetence([FromBody] AddCandidateCompetenceDTO addCandidateCompetenceDto)
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

		[HttpPost("Languages")]
		public async Task<ActionResult> AddCandidateLanguageAsync([FromBody] AddCandidateLanguageDTO addCandidateLanguageDTO)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			try
			{
				await _candidateService.AddCandidateLanguageAsync(addCandidateLanguageDTO);
				return NoContent();
			}
			catch (DbUpdateException ex)
			{
				return StatusCode(500, "An error occurred while trying to save the changes.");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			} 
		}
	}
}

using JobMatching.Application.DTO;
using JobMatching.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JobMatching.API.Controllers
{
	[Route("api/competences")]
	[ApiController]
	public class CompetencesController : ControllerBase
	{
		private readonly ICompetenceService _competenceService;

		public CompetencesController(ICompetenceService competenceService)
		{
			_competenceService = competenceService;
		}

		[HttpGet]
		public async Task<ActionResult<List<CompetenceDTO>>> GetCompetencesAsync()
		{
			return Ok(await _competenceService.GetCompetencesAsync());
		}

		[HttpGet("{competenceId}")]
		public async Task<ActionResult<CompetenceDTO>> GetCompetenceByIdAsync(Guid competenceId)
		{
			if (competenceId == Guid.Empty)
				return BadRequest("Invalid competence ID.");

			var competenceDto = _competenceService.GetCompetenceByIdAsync(competenceId);

			return competenceDto == null
				? NotFound($"User with the specified {competenceId} could not be found.")
				: Ok(competenceDto);
		}
	}
}

using JobMatching.Application.DTO.Shared;
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
	}
}

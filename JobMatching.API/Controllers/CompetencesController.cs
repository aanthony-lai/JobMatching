using JobMatching.Application.CompetenceServices;
using JobMatching.Domain.Entities.Competence;
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
        public async Task<ActionResult<List<Competence>>> GetAsync()
        {
            return Ok(await _competenceService.GetAsync());
        }
    }
}

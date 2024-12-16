using JobMatching.Application.DTO.Candidate;
using JobMatching.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public async Task<ActionResult<List<CandidateDTO>>> GetAsync()
        {
            return await _candidateService.GetAsync();
        }

        [HttpGet("{candidateId}")]
        public async Task<ActionResult<CandidateDTO>> GetByIdAsync(Guid candidateId)
        {
            var result = await _candidateService.GetByIdAsync(candidateId);

            return result.Match<ActionResult>(
                success => Ok(result.Value),
                failure => BadRequest(result.Error.ToString()));
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync(CreateCandidateDTO createCandidateDto)
        {
            var result = await _candidateService.AddAsync(createCandidateDto);

            return result.Match<ActionResult>(
                success => CreatedAtAction(
                    nameof(GetByIdAsync),
                    new { candidateId = result.Value.Id },
                    new { result.Value }),
                failure => BadRequest(result.Error.ToString()));
        }
    }
}

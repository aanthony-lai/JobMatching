using JobMatching.Application.DTO.Candidate;
using JobMatching.Application.DTO.JobApplication;
using JobMatching.Application.Interfaces;
using JobMatching.Common.Results;
using JobMatching.Common.SystemMessages.CandidateMessages;
using JobMatching.Domain.Entities;
using JobMatching.Domain.Entities.JunctionEntities;
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

        //
        //This one should probably be removed later.
        //
        [HttpGet("shouldBeRemovedLater")]
        public async Task<ActionResult<List<CandidateDTO>>> GetAllAsync()
        {
            return Ok(await _candidateService.GetCandidatesAsync());
        }

        [HttpGet("{candidateId}")]
        public async Task<ActionResult<CandidateDTO?>> GetByIdAsync(Guid candidateId)
        {
            if (candidateId == Guid.Empty)
                return BadRequest("Invalid candidate ID.");

            Result<CandidateDTO> result = await _candidateService.GetByIdAsync(candidateId);

            return result.Match<ActionResult>(
                success => Ok(result.Value),
                failure => NotFound(result.Error.ToString()));
        }

        [HttpGet("{candidateId}/job-applications")]
        public async Task<ActionResult<List<JobApplicationDTO>>> GetJobApplicationsByCandidateId(Guid candidateId)
        {
            if (candidateId == Guid.Empty)
                return BadRequest(CandidateMessages.InvalidCandidateId(candidateId));

            if (!await _candidateService.ExistsAsync(candidateId))
                return NotFound(CandidateMessages.CandidateNotFound(candidateId));

            return Ok(await _jobApplicationService.GetByCandidateIdAsync(candidateId));
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] CreateCandidateDTO createCandidateDto)
        {
            Result<Candidate> result = await _candidateService.AddAsync(createCandidateDto);

            return result.Match<ActionResult>(
                success => CreatedAtAction(
                    nameof(GetByIdAsync),
                    new { candidateId = result.Value.Id },
                    result.Value),
                failure => BadRequest(failure.ToString()));
        }

        [HttpPost("{candidateId}/competences")]
        public async Task<ActionResult> CreateCompetence(Guid candidateId, [FromBody] AddCandidateCompetenceDTO addCandidateCompetenceDto)
        {
            try
            {
                await _candidateService.AddCandidateCompetence(candidateId, addCandidateCompetenceDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{candidateId}/languages")]
        public async Task<ActionResult> CreateLanguageAsync(Guid candidateId, [FromBody] AddCandidateLanguageDTO addCandidateLanguageDTO)
        {
            Result<CandidateLanguage> result = await _candidateService
                .AddCandidateLanguageAsync(candidateId, addCandidateLanguageDTO);

            return result.Match<ActionResult>(
                success => NoContent(),
                failure => BadRequest(result.Error.ToString()));
        }
    }
}

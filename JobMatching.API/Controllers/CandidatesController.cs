using JobMatching.Application.Candidates;
using JobMatching.Application.Candidates.GetJobApplications;
using JobMatching.Application.DTO.Candidate;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobMatching.API.Controllers
{
    [Route("api/candidates")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly ICandidateService _candidateService;
        private readonly IMediator _mediator;

        public CandidatesController(
            ICandidateService candidateService,
            IMediator mediator)
        {
            _candidateService = candidateService;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CandidateDTO>>> GetAsync()
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

        [HttpGet("{candidateId}/job-applications")]
        public async Task<ActionResult<IEnumerable<JobApplicationDTO>>> GetJobApplicationsAsync(Guid candidateId)
        {
            var jobApplicationsResult = await _mediator.Send(new GetJobApplicationsRequest(candidateId));

            return jobApplicationsResult.Match<ActionResult>(
                succuess => Ok(jobApplicationsResult.Value),
                failure => BadRequest(jobApplicationsResult.Error.ToString()));
        }
    }
}

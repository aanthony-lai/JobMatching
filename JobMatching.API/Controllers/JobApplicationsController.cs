using JobMatching.Application.DTO.JobApplication;
using JobMatching.Application.Interfaces;
using JobMatching.Common.Results;
using JobMatching.Domain.Entities;
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
            return Ok(await _jobApplicationService.GetAllAsync());
        }

        [HttpPost]
        public async Task<ActionResult> CreateJobApplicationAsync([FromBody] CreateJobApplicationDTO createJobApplicationDTO)
        {
            Result<JobApplication> result = await _jobApplicationService
                .AddAsync(createJobApplicationDTO);

            return result.Match<ActionResult>(
                success => NoContent(),
                failure => BadRequest(result.Error.ToString()));
        }
    }
}

using JobMatching.Application.DTO.Job;
using JobMatching.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobMatching.API.Controllers
{
    [Route("api/jobs")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobsController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpGet]
        public async Task<ActionResult<List<JobDTO>>> GetAsync()
        {
            return Ok(await _jobService.GetAsync());
        }

        [HttpGet("{jobId}")]
        public async Task<ActionResult<JobDTO>> GetByIdAsync(Guid jobId)
        {
            var result = await _jobService.GetByIdAsync(jobId);

            return result.Match<ActionResult>(
                success => Ok(result.Value),
                failure => BadRequest(result.Error.ToString()));
        }

        [HttpGet("name/{jobName}")]
        public async Task<ActionResult<List<JobDTO>>> GetByNameAsync(string name)
        {
            return Ok(await _jobService.GetByNameAsync(name));
        }

        [HttpPost("{employerId}")]
        public async Task<ActionResult> AddAsync(Guid employerId, CreateJobDTO createJobDTO)
        {
            var result = await _jobService.AddAsync(employerId, createJobDTO);

            return result.Match<ActionResult>(
                success => CreatedAtAction(
                    nameof(GetByIdAsync),
                    new { jobId = result.Value.Id },
                    new { result.Value }),
                failure => BadRequest(result.Error.ToString()));
        }
    }
}

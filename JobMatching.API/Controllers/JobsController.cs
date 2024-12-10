using JobMatching.Application.DTO.Job;
using JobMatching.Application.Interfaces;
using JobMatching.Common.Results;
using JobMatching.Domain.Entities;
using JobMatching.Domain.Entities.JunctionEntities;
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
        public async Task<ActionResult<List<JobDTO>>> GetAllAsync()
        {
            return Ok(await _jobService.GetJobsAsync());
        }

        [HttpGet("{jobTitle}")]
        public async Task<ActionResult<List<JobDTO>>> GetByTitleAsync(string jobTitle)
        {
            if (string.IsNullOrWhiteSpace(jobTitle))
                return BadRequest("No jobs found.");

            var jobsDto = await _jobService.GetByJobTitleAsync(jobTitle);
            return Ok(jobsDto);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] CreateJobDTO dto)
        {
            if (dto.EmployerId == Guid.Empty)
                return BadRequest("Invalid employer ID.");

            Result<Job> result = await _jobService.AddAsync(dto);

            return result.Match<ActionResult>(
                success => NoContent(),
                failure => BadRequest(result.Error.ToString()));
        }

        [HttpPost("{jobId}/competence")]
        public async Task<ActionResult> CreateCompetenceAsync(Guid jobId, [FromBody] AddJobCompetenceDTO dto)
        {
            if (jobId == Guid.Empty)
                return BadRequest("Invalid job ID.");

            Result<JobCompetence> result = await _jobService.AddJobCompetence(jobId, dto);

            return result.Match<ActionResult>(
                success => NoContent(),
                failure => BadRequest(result.Error.ToString()));
        }
    }
}

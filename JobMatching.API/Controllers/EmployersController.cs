using JobMatching.Application.DTO.Employer;
using JobMatching.Application.Interfaces.Services;
using JobMatching.Application.Utilities;
using JobMatching.Common.Results;
using JobMatching.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace JobMatching.API.Controllers
{
    [Route("api/employers")]
    [ApiController]
    public class EmployersController : ControllerBase
    {
        private readonly IEmployerService _employerService;

        public EmployersController(IEmployerService employerService)
        {
            _employerService = employerService;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployerDTO>>> GetAsync()
        {
            return Ok(await _employerService.GetAsync());
        }

        [HttpGet("{employerId}")]
        public async Task<ActionResult<EmployerDTO>> GetByIdAsync(Guid employerId)
        {
            var result = await _employerService.GetByIdAsync(employerId);

            return result.Match<ActionResult>(
                success => Ok(result.Value),
                failure => BadRequest(result.Error.ToString()));
        }

        [HttpGet("name/{employerName}")]
        public async Task<ActionResult<EmployerDTO>> GetByNameAsync(string employerName)
        {
            var result = await _employerService.GetByNameAsync(employerName);

            return result.Match<ActionResult>(
                success => Ok(result.Value),
                failure => BadRequest(result.Error.ToString()));
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody]CreateEmployerDTO createEmployerDto)
        {
            var result = await _employerService.AddAsync(createEmployerDto);

            return result.Match<ActionResult>(
                success => CreatedAtAction(
                    nameof(GetByIdAsync),
                    new { employerId = result.Value.Id },
                    new { result.Value }),
                failure => BadRequest(result.Error.ToString()));
        }
    }
}

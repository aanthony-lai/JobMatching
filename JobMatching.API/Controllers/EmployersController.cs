using JobMatching.Application.DTO.Employer;
using JobMatching.Application.Interfaces;
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
        public async Task<ActionResult<List<EmployerDTO>>> GetAllAsync()
        {
            return await _employerService.GetAllAsync();
        }

        [HttpGet("{employerId}")]
        public async Task<ActionResult<EmployerDTO>> GetByIdAsync([FromRoute] Guid employerId)
        {
            if (employerId == Guid.Empty)
                return BadRequest("Invalid employer ID.");

            Result<EmployerDTO> result = await _employerService.GetByIdAsync(employerId);

            return result.Match<ActionResult>(
                success => Ok(result.Value),
                failture => NotFound(result.Error.ToString()));
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] CreateEmployerDTO createEmployerDto)
        {
            Result<Employer> result = await _employerService
                .AddAsync(createEmployerDto);

            return result.Match<ActionResult>(
                success => CreatedAtAction(
                    nameof(GetByIdAsync),
                    new { employerId = result.Value.Id },
                    result.Value),
                failure => BadRequest(result.Error.ToString()));
        }
    }
}

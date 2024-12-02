using JobMatching.Application.DTO.Applicant;
using JobMatching.Application.Interfaces;
using JobMatching.Common.SystemMessages.JobMessages;
using Microsoft.AspNetCore.Mvc;

namespace JobMatching.API.Controllers
{
	[Route("api/applicants")]
	[ApiController]
	public class ApplicantsController : ControllerBase
	{
		private readonly IApplicantService _applicantService;

		public ApplicantsController(IApplicantService applicantService) 
		{
			_applicantService = applicantService;
		}

		//Should maybe be changed to use employer id instead. 
		[HttpGet("{jobId}")]
		public async Task<ActionResult<List<ApplicantDTO>>> GetApplicantsByJobIdAsync(Guid jobId)
		{
			if (jobId == Guid.Empty)
				return BadRequest(JobMessages.InvalidJobId(jobId));

			return await _applicantService.GetApplicantsByJobIdAsync(jobId);
		}
	}
}

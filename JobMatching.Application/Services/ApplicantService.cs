using JobMatching.Application.DTO.Applicant;
using JobMatching.Application.Interfaces;
using JobMatching.Application.Utilities;
using JobMatching.Domain.Interfaces;

namespace JobMatching.Application.Services
{
	public class ApplicantService : IApplicantService
	{
		private readonly IJobApplicationRepository _jobApplicationRepository;
		private readonly IJobMatchService _jobMatchService;

		public ApplicantService(IJobApplicationRepository jobApplicationRepository,
			IJobMatchService jobMatchService)
		{
			_jobApplicationRepository = jobApplicationRepository;
			_jobMatchService = jobMatchService;
		}

		public async Task<List<ApplicantDTO>> GetApplicantsByJobIdAsync(Guid jobId)
		{
			var applicants = await _jobApplicationRepository.GetApplicantsByJobIdAsync(jobId, withTracking: false);

			List<ApplicantDTO> applicantsDto = new List<ApplicantDTO>();

			foreach (var applicant in applicants)
			{
				applicantsDto.Add(new ApplicantDTO(
					jobApplicationId: applicant.JobApplicationId,
					candidate: CandidateMapper.MapCandidate(applicant.Candidate),
					job: EmployerJobMapper.MapEmployerJob(applicant.Job),
					applicationDate: applicant.ApplicationDate,
					status: applicant.ApplicationStatus,
					matchGrade: _jobMatchService.CalculateMatchGrade(applicant)));
			}

			return applicantsDto;
		}
	}
}

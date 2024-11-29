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
			var jobApplications = await _jobApplicationRepository.GetJobApplicationsByJobIdAsync(jobId, withTracking: false);

			List<ApplicantDTO> applicantsDto = new();

			foreach (var jobApplication in jobApplications)
			{
				decimal criticalCompetencesMatchGrade = _jobMatchService
					.CalculateMatchGrade(jobApplication, calculateForCriticalCompetences: true);

				decimal nonCriticalCompetencesMatchGrade = _jobMatchService
					.CalculateMatchGrade(jobApplication, calculateForCriticalCompetences: false);

				applicantsDto.Add(ApplicantMapper.MapApplicant(
					jobApplication, 
					criticalCompetencesMatchGrade, 
					nonCriticalCompetencesMatchGrade));
			}
			return applicantsDto;
		}
	}
}

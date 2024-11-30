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
			//var jobApplications = await _jobApplicationRepository.GetJobApplicationsByJobIdAsync(jobId, withTracking: false);

			//List<ApplicantDTO> applicantsDto = new();

			var jobApplications = await _jobApplicationRepository.GetJobApplicationsByJobIdAsync(jobId, withTracking: false);

			var applicantsDto = jobApplications.Select(jobApplication =>
			{
				ApplicantDTO applicantDto = ApplicantMapper.MapApplicant(jobApplication);

				applicantDto.MeetsCriticalCompetences = _jobMatchService.DoesCandidateHaveAllCriticalCompetences(jobApplication);
				applicantDto.CriticalCompetencesMatchSummary = _jobMatchService.GetCricitcalCompetencesMatchSummary(jobApplication);
				applicantDto.OverallMatchGrade = _jobMatchService.CalculateOverallMatchGrade(jobApplication);

				return applicantDto;
			}).ToList();

			return applicantsDto;


			//return jobApplications.Select(jobApplication =>
			//{
			//	ApplicantDTO applicantDto = ApplicantMapper.MapApplicant(jobApplication);

			//	applicantDto.MeetsCriticalCompetences = _jobMatchService.DoesCandidateHaveAllCriticalCompetences(jobApplication);
			//	applicantDto.CriticalCompetencesMatchSummary = _jobMatchService.GetCricitcalCompetencesMatchSummary(jobApplication);
			//	applicantDto.OverallMatchGrade = _jobMatchService.CalculateOverallMatchGrade(jobApplication);

			//	applicantsDto.Add(applicantDto);
			//});
			//return applicantsDto;
			//foreach (var jobApplication in jobApplications)
			//{
			//	ApplicantDTO applicantDto = ApplicantMapper.MapApplicant(jobApplication); 

			//	applicantDto.MeetsCriticalCompetences = _jobMatchService.DoesCandidateHaveAllCriticalCompetences(jobApplication);
			//	applicantDto.CriticalCompetencesMatchSummary = _jobMatchService.GetCricitcalCompetencesMatchSummary(jobApplication);
			//	applicantDto.OverallMatchGrade = _jobMatchService.CalculateOverallMatchGrade(jobApplication);

			//	applicantsDto.Add(applicantDto);
			//}

		}
	}
}

using JobMatching.Application.DTO.Applicant;
using JobMatching.Application.DTO.Candidate;
using JobMatching.Application.DTO.JobApplication;
using JobMatching.Domain.Entities;

namespace JobMatching.Application.Utilities
{
	public static class ApplicantMapper
	{
		public static ApplicantDTO MapApplicant(JobApplication jobApplication)
		{
			if (jobApplication is null)
				throw new ArgumentNullException(nameof(jobApplication), "Cannot map null to ApplicantDTO.");

			return new ApplicantDTO(
				JobApplicationId: jobApplication.Id,
				Candidate: new JobApplicationCandidateDTO(
					jobApplication.CandidateId,
					jobApplication.Candidate.Name.FirstName,
					jobApplication.Candidate.Name.LastName,
					jobApplication.Candidate.Competences
						.Select(comp => comp.CompetenceName).ToArray(),
					jobApplication.Candidate.Languages
						.Select(lan => new CandidateLanguageDTO(
							lan.Language.Name,
							lan.ProficiencyLevel.ToString())).ToList(),
					jobApplication.Candidate.HasDriversLicence),
				Job: EmployerJobMapper.MapEmployerJob(jobApplication.Job),
				ApplicationDate: jobApplication.ApplicationDate,
				Status: jobApplication.ApplicationStatus);
		}
	}
}

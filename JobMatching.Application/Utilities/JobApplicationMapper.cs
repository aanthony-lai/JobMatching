using JobMatching.Application.DTO.Candidate;
using JobMatching.Application.DTO.JobApplication;
using JobMatching.Application.DTO.Shared;
using JobMatching.Domain.Entities;

namespace JobMatching.Application.Utilities
{
	public static class JobApplicationMapper
	{
		public static JobApplicationDTO MapJobApplication(JobApplication jobApplication)
		{
			if (jobApplication is null)
				throw new ArgumentNullException("Cannot map null to JobApplicationDTO.", nameof(jobApplication));

			return new JobApplicationDTO(
				JobApplicationId: jobApplication.Id,
				Candidate: new JobApplicationCandidateDTO(
					jobApplication.Candidate.Id,
                    jobApplication.Candidate.Name.FirstName!,
                    jobApplication.Candidate.Name.LastName!,
                    jobApplication.Candidate.Competences.Select(
						comp => new CompetenceDTO(
							comp.Id, 
							comp.CompetenceName)).ToList(),
					Languages: jobApplication.Candidate.Languages.Select(
						lan => new CandidateLanguageDTO(
							lan.Language.Name, 
							lan.ProficiencyLevel.ToString())).ToList(),
					HasDriversLicense: jobApplication.Candidate.HasDriversLicence),
				Job: EmployerJobMapper.MapEmployerJob(jobApplication.Job),
				ApplicationDate: jobApplication.ApplicationDate,
				Status: jobApplication.ApplicationStatus);
		}

		public static List<JobApplicationDTO> MapJobApplications(List<JobApplication> jobApplications) =>
			jobApplications.Select(MapJobApplication).ToList();
	}
}

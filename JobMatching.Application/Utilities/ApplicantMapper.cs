using JobMatching.Application.DTO.Applicant;
using JobMatching.Domain.Entities;

namespace JobMatching.Application.Utilities
{
	public static class ApplicantMapper
	{
		public static ApplicantDTO MapApplicant(JobApplication jobApplication, decimal matchGrade)
		{
			if (jobApplication is null)
				throw new ArgumentNullException(nameof(jobApplication), "Job application cabbit be null when mapping to ApplicantDTO.");

			return new ApplicantDTO(
				jobApplicationId: jobApplication.JobApplicationId,
				candidate: CandidateMapper.MapCandidate(jobApplication.Candidate),
				job: EmployerJobMapper.MapEmployerJob(jobApplication.Job),
				applicationDate: jobApplication.ApplicationDate,
				status: jobApplication.ApplicationStatus,
				matchGrade: matchGrade);
		}

		public static List<ApplicantDTO> MapApplicants(List<JobApplication> jobApplications, Func<JobApplication, decimal> calculateMatchGrade)
		{
			return jobApplications
				.Select(jobApplication => MapApplicant(jobApplication, calculateMatchGrade(jobApplication)))
				.ToList();
		}
	}
}

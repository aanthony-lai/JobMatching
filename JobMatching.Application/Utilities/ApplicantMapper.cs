using JobMatching.Application.DTO.Applicant;
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
				jobApplicationId: jobApplication.Id,
				candidate: CandidateMapper.MapCandidate(jobApplication.Candidate),
				job: EmployerJobMapper.MapEmployerJob(jobApplication.Job),
				applicationDate: jobApplication.ApplicationDate,
				status: jobApplication.ApplicationStatus);
		}
	}
}

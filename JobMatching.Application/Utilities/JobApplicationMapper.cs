using JobMatching.Application.DTO.JobApplication;
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
				jobApplicationId: jobApplication.JobApplicationId,
				candidate: CandidateMapper.MapCandidate(jobApplication.Candidate),
				job: JobMapper.MapJob(jobApplication.Job),
				applicationDate: jobApplication.ApplicationDate,
				status: jobApplication.ApplicationStatus);
		}

		public static List<JobApplicationDTO> MapJobApplications(List<JobApplication> jobApplications) =>
			jobApplications.Select(MapJobApplication).ToList();
	}
}

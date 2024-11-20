using JobMatching.Application.DTO;
using JobMatching.Domain.Entities;

namespace JobMatching.Application.Utilities.Mappers
{
	public static class JobApplicationMapper
	{
		public static JobApplicationDTO? Map(JobApplication jobApplication)
		{
			if (jobApplication is null)
				throw new ArgumentNullException("Cannot map null to JobApplicationDTO.", nameof(jobApplication));

			return new JobApplicationDTO(
				applicationId: jobApplication.JobApplicationId,
				job: UserJobMapper.Map(jobApplication.Job),
				applicationDate: jobApplication.ApplicationDate,
				applicationStatus: jobApplication.ApplicationStatus);
		}
	}
}

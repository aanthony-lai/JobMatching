using JobMatching.Application.DTO;
using JobMatching.Domain.Entities;

namespace JobMatching.Application.Utilities.Mappers
{
	public class JobApplicationsMapper
	{
		public static List<JobApplicationDTO> Map(List<JobApplication> applications)
		{
			return applications.Select(application => new JobApplicationDTO(
				applicationId: application.JobApplicationId,
				job: UserJobMapper.Map(application.Job),
				applicationDate: application.ApplicationDate,
				applicationStatus: application.ApplicationStatus))
				.ToList();
		}
	}
}

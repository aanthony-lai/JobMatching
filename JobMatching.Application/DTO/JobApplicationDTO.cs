using JobMatching.Domain.Enums;

namespace JobMatching.Application.DTO
{
	public class JobApplicationDTO(
		Guid applicationId,
		UserJobDTO? job,
		DateTime applicationDate,
		ApplicationStatus applicationStatus);
}

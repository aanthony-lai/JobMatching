using JobMatching.Domain.Enums;

namespace JobMatching.Application.DTO
{
	public record ApplicantDTO(
		Guid applicationId,
		Guid userId,
		string firstName,
		string lastName,
		DateTime applicationDate,
		ApplicationStatus applicationStatus);
}

namespace JobMatching.Application.DTO
{
	public record UserJobDTO(
		Guid jobId,
		string jobTitle,
		int? salaryTop,
		int? salaryBottom,
		string employerName,
		List<CompetenceDTO>? competences);
}

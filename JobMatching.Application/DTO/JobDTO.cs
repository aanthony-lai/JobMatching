namespace JobMatching.Application.DTO
{
	public record JobDTO(
		Guid jobId,
		string jobTitle,
		int? salaryTop,
		int? salaryBottom,
		string employerName,
		List<CompetenceDTO> competencesDto);
}

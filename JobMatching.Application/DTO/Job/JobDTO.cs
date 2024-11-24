using JobMatching.Application.DTO.Shared;

namespace JobMatching.Application.DTO.Job
{
	public record JobDTO(
		Guid jobId,
		string jobTitle,
		int? salaryRangeTop,
		int? salaryRangeBottom,
		string employerName,
		List<CompetenceDTO> competences);
}

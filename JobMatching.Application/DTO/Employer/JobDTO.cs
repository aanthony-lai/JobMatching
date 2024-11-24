using JobMatching.Application.DTO.Shared;

namespace JobMatching.Application.DTO.Employer
{
    public record JobDTO(
		Guid jobId,
		string jobTitle,
		int? salaryRangeTop,
		int? salaryRangeBottom,
		List<CompetenceDTO> competences);
}

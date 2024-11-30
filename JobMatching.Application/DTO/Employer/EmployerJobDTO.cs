using JobMatching.Application.DTO.Shared;

namespace JobMatching.Application.DTO.Employer
{
    public record EmployerJobDTO(
		Guid jobId,
		string jobTitle,
		int? salaryRangeTop,
		int? salaryRangeBottom,
		List<CompetenceDTO> criticalCompetences,
		List<CompetenceDTO> nonCriticalCompetences);
}

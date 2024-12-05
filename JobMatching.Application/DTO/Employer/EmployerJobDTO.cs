using JobMatching.Application.DTO.Shared;

namespace JobMatching.Application.DTO.Employer
{
    public record EmployerJobDTO(
		Guid JobId,
		string JobTitle,
		int? SalaryRangeTop,
		int? SalaryRangeBottom,
		string[] CriticalCompetences,
		string[] NonCriticalCompetences);
}

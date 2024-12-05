using JobMatching.Application.DTO.Shared;

namespace JobMatching.Application.DTO.Job
{
	public record JobDTO(
		Guid JobId,
		string JobTitle,
		int? SalaryRangeTop,
		int? SalaryRangeBottom,
		string EmployerName,
		string[] CriticalCompetences,
		string[] NonCriticalCompetences);
}

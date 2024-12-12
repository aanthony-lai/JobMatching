using JobMatching.Application.DTO.Shared;

namespace JobMatching.Application.DTO.Employer
{
    public record EmployerJobDTO(
		Guid JobId,
		string Title,
		int? MaxSalary,
		int? MinSalary,
		string[] CriticalCompetences,
		string[] NonCriticalCompetences);
}

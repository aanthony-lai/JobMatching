using JobMatching.Domain.ValueObjects;

namespace JobMatching.Application.DTO.Job
{
	public record CreateJobDTO(
		string jobTitle,
		Guid EmployerId,
		SalaryRange? salaryRange = null);
}

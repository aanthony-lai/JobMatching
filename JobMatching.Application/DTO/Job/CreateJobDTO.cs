using JobMatching.Domain.Entities.ValueObjects;

namespace JobMatching.Application.DTO.Job
{
    public record CreateJobDTO(
		Guid EmployerId,
		string Title,
		Salary? Salary = null);
}

namespace JobMatching.Application.DTO.Employer
{
	public record EmployerDTO(
		Guid Id,
		string Name,
		List<EmployerJobDTO> Jobs);
}

namespace JobMatching.Application.DTO
{
	public record EmployerDTO(
		Guid employerId,
		string employerName,
		List<EmployerJobDTO> jobs);
}

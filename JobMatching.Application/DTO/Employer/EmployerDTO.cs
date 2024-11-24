namespace JobMatching.Application.DTO.Employer
{
	public record EmployerDTO(
		Guid employerId,
		string employerName,
		List<EmployerJobDTO> jobs);
}

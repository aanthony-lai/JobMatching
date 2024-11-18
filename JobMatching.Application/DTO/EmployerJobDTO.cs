namespace JobMatching.Application.DTO
{
	public record EmployerJobDTO(
		Guid jobId,
		string jobTitle,
		int? salaryTop,
		int? salaryBottom,
		List<CompetenceDTO> competences,
		List<ApplicantDTO> applicants);
}

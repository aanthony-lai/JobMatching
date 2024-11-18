namespace JobMatching.Application.DTO
{
	public record UserDTO(
		Guid userId,
		string firstName,
		string lastName,
		List<CompetenceDTO> competences,
		List<JobApplicationDTO> applications);
}

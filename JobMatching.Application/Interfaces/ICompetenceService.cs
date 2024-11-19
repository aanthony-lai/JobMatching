using JobMatching.Application.DTO;

namespace JobMatching.Application.Interfaces
{
	public interface ICompetenceService
	{
		Task<CompetenceDTO?> GetCompetenceByIdAsync(Guid competenceId);
		Task<List<CompetenceDTO>> GetCompetencesAsync();
	}
}

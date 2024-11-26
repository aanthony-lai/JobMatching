using JobMatching.Application.DTO.Shared;

namespace JobMatching.Application.Interfaces;

    public interface ICompetenceService
{
	Task<List<CompetenceDTO>> GetCompetencesAsync();
}

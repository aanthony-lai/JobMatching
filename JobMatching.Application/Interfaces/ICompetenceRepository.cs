using JobMatching.Domain.Entities;

namespace JobMatching.Application.Interfaces;

public interface ICompetenceRepository
{
	Task<Competence?> GetCompetenceByIdAsync(Guid competenceId, bool withTracking = true);
	Task<List<Competence>> GetCompetencesAsync(bool withTracking = true);
}

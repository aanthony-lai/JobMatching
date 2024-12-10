using JobMatching.Domain.Entities;

namespace JobMatching.Application.Interfaces;

public interface ICompetenceRepository
{
	Task<Competence?> GetByIdAsync(Guid competenceId, bool withTracking = true);
	Task<List<Competence>> GetAllAsync(bool withTracking = true);
	Task<bool> ExistsAsync(Guid competenceId);
}

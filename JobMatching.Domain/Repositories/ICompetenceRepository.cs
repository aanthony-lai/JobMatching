using JobMatching.Domain.Entities;

namespace JobMatching.Domain.Repositories;

public interface ICompetenceRepository
{
	Task<Competence?> GetByIdAsync(Guid competenceId, bool withTracking = true);
	Task<List<Competence>> GetAllAsync(bool withTracking = true);
	Task<bool> ExistsAsync(Guid competenceId);
}

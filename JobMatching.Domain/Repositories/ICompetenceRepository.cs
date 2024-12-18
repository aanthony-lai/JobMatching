using JobMatching.Domain.Entities.Competence;

namespace JobMatching.Domain.Repositories;

public interface ICompetenceRepository
{
    Task<List<Competence>> GetAsync(bool withTracking = false);
    Task<Competence?> GetByIdAsync(Guid competenceId, bool withTracking = false);

}

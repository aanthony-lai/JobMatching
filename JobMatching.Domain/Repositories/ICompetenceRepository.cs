using JobMatching.Domain.Entities.Competence;

namespace JobMatching.Domain.Repositories;

public interface ICompetenceRepository
{
    Task<IEnumerable<Competence>> GetAsync(bool withTracking = false);
    Task SaveAsync(Competence competence);
    Task SaveAsync();
}

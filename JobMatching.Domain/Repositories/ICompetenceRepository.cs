using JobMatching.Domain.Entities.Competence;

namespace JobMatching.Domain.Repositories;

public interface ICompetenceRepository
{
    Task<List<Competence>> GetAsync(bool withTracking);
    Task<bool> SaveAsync(Competence competence);
    Task<bool> UpdateAsync(Competence competence);
}

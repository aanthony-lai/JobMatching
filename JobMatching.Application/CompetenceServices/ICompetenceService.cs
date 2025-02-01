using JobMatching.Domain.Entities.Competence;

namespace JobMatching.Application.CompetenceServices;

public interface ICompetenceService
{
    Task<IEnumerable<Competence>> GetAsync();
}

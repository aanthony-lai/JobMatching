using JobMatching.Domain.Entities.Competence;

namespace JobMatching.Application.CompetenceServices;

public interface ICompetenceService
{
    Task<List<Competence>> GetAsync();
}

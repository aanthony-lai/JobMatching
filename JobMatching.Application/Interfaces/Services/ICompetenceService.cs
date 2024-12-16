using JobMatching.Domain.Entities.Competence;

namespace JobMatching.Application.Interfaces.Services;

public interface ICompetenceService
{
    Task<List<Competence>> GetAsync();
}

using JobMatching.Domain.Entities.Competence;
using JobMatching.Domain.Repositories;

namespace JobMatching.Application.CompetenceServices
{
    public class CompetenceService(ICompetenceRepository competenceRepository) : ICompetenceService
    {
        public async Task<IEnumerable<Competence>> GetAsync() => await competenceRepository.GetAsync();
    }
}

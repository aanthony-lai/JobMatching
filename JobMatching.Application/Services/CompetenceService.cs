using JobMatching.Application.Interfaces.Services;
using JobMatching.Domain.Entities.Competence;
using JobMatching.Domain.Repositories;

namespace JobMatching.Application.Services
{
    public class CompetenceService : ICompetenceService
    {
        private readonly ICompetenceRepository _competenceRepository;

        public CompetenceService(ICompetenceRepository competenceRepository)
        {
            _competenceRepository = competenceRepository;
        }

        public async Task<List<Competence>> GetAsync()
        {
            return await _competenceRepository.GetAsync();
        }
    }
}

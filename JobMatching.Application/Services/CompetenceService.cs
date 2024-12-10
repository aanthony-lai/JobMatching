using JobMatching.Application.DTO.Shared;
using JobMatching.Application.Interfaces;
using JobMatching.Application.Utilities;

namespace JobMatching.Application.Services
{
    public class CompetenceService : ICompetenceService
	{
		private readonly ICompetenceRepository _competenceRepository;

		public CompetenceService(ICompetenceRepository competenceRepository)
		{
			_competenceRepository = competenceRepository;
		}
		public async Task<List<CompetenceDTO>> GetCompetencesAsync()
		{
			var competences = await _competenceRepository.GetAllAsync(withTracking: false);

			return CompetenceMapper.MapCompetences(competences);
		}
	}
}

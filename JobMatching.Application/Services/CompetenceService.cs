using JobMatching.Application.DTO;
using JobMatching.Application.Interfaces;
using JobMatching.Application.Utilities.Mappers;

namespace JobMatching.Application.Services
{
	public class CompetenceService: ICompetenceService
	{
		private readonly ICompetenceRepository _competenceRepository;

		public CompetenceService(ICompetenceRepository competenceRepository)
		{
			_competenceRepository = competenceRepository;
		}
		public async Task<List<CompetenceDTO>> GetCompetencesAsync()
		{
			var competences = await _competenceRepository.GetCompetencesAsync(withTracking: false);

			return CompetencesMapper.Map(competences);
		}

		public async Task<CompetenceDTO?> GetCompetenceByIdAsync(Guid competenceId)
		{
			var competence = await _competenceRepository.GetCompetenceByIdAsync(competenceId, withTracking: false);

			return CompetenceMapper.Map(competence);
		}
	}
}

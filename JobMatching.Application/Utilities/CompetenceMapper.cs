using JobMatching.Application.DTO.Shared;
using JobMatching.Domain.Entities;

namespace JobMatching.Application.Utilities
{
    public static class CompetenceMapper
	{
		public static CompetenceDTO MapCompetence(Competence competence)
		{
			if (competence is null)
				throw new ArgumentNullException("Cannot map null to CompetenceDTO", nameof(competence));

			return new CompetenceDTO(
				competenceId: competence.CompetenceId,
				competenceName: competence.CompetenceName);
		}

		public static List<CompetenceDTO> MapCompetences(List<Competence> competences) => 
			competences.Select(MapCompetence).ToList();
	}
}

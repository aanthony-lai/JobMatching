using JobMatching.Application.DTO;
using JobMatching.Domain.Entities;

namespace JobMatching.Application.Utilities.Mappers
{
    public static class CompetencesMapper
    {
        public static List<CompetenceDTO> Map(List<Competence> competences)
        {
			return competences.Select(competence => new CompetenceDTO(
                competenceId: competence.CompetenceId,
                competenceName: competence.CompetenceName))
                .ToList();
        }
    }
}

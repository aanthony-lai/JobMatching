using JobMatching.Application.DTO.Shared;
using JobMatching.Domain.Entities;
using JobMatching.Domain.Entities.JunctionEntities;

namespace JobMatching.Application.Utilities
{
    public static class CompetenceMapper
	{
		public static CompetenceDTO MapCompetence(Competence competence)
		{
			if (competence is null)
				throw new ArgumentNullException("Cannot map null to CompetenceDTO", nameof(competence));

			return new CompetenceDTO(
				competenceId: competence.Id,
				competenceName: competence.CompetenceName);
		}

		public static CompetenceDTO MapJobCompetence(JobCompetence jobCompetence)
		{
			if (jobCompetence is null)
				throw new ArgumentNullException("Cannot map null to CompetenceDTO", nameof(jobCompetence));

			return new CompetenceDTO(
				competenceId: jobCompetence.Competence.Id,
				competenceName: jobCompetence.Competence.CompetenceName);
		}

		public static List<CompetenceDTO> MapCompetences(List<Competence> competences) => 
			competences.Select(MapCompetence).ToList();
		public static List<CompetenceDTO> MapJobCompetences(List<JobCompetence> jobCompetences) =>
			jobCompetences.Select(MapJobCompetence).ToList();
	}
}

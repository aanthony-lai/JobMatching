using JobMatching.Application.DTO;
using JobMatching.Domain.Entities;

namespace JobMatching.Application.Utilities.Mappers
{
	public static class CompetenceMapper
	{
		public static CompetenceDTO Map(Competence competence)
		{
			if (competence is null)
				throw new ArgumentNullException("Cannot map null to UserDTO.", nameof(competence));

			return new CompetenceDTO(
				competenceId: competence.CompetenceId,
				competenceName: competence.CompetenceName);
		}
	}
}

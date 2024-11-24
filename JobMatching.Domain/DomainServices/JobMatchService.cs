using JobMatching.Domain.Entities;
using JobMatching.Domain.Interfaces;

namespace JobMatching.Domain.DomainServices
{
	public class JobMatchService: IJobMatchService
	{
		public decimal CalculateMatchGrade(JobApplication jobApplication)
		{
			if (!jobApplication.Candidate.Competences.Any() ||
				!jobApplication.Job.Competences.Any())
				return 0;

			List<Competence> userCompetences = jobApplication.Candidate.Competences;
			List<Competence> jobRequiredCompetences = jobApplication.Job.Competences;

			int totalRequiredCompetences = jobRequiredCompetences.Count;
			int matchingCompetences = jobRequiredCompetences
				.Count(jobCompetence => userCompetences.Any(userCompetence => userCompetence.CompetenceId == jobCompetence.CompetenceId));

			return ((decimal)matchingCompetences / totalRequiredCompetences) * 100;
		}
	}
}

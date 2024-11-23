using JobMatching.Domain.Entities;
using JobMatching.Domain.Interfaces;

namespace JobMatching.Domain.DomainServices
{
	public class JobMatchService: IJobMatchService
	{
		public decimal CalculateMatchGrade(JobApplication jobApplication)
		{
			if (!jobApplication.User.Competences.Any() ||
				!jobApplication.Job.Competences.Any())
				return 0;

			List<Competence> userCompetences = jobApplication.User.Competences;
			List<Competence> jobRequiredCompetences = jobApplication.Job.Competences;

			int totalRequiredCompetences = jobRequiredCompetences.Count;
			int matchingCompetences = jobRequiredCompetences.Count(userCompetences.Contains);

			return ((decimal)matchingCompetences / totalRequiredCompetences) * 100;
		}
	}
}

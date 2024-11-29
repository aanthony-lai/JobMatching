using JobMatching.Domain.Entities;
using JobMatching.Domain.Entities.JunctionEntities;
using JobMatching.Domain.Interfaces;

namespace JobMatching.Domain.DomainServices
{
	public class JobMatchService: IJobMatchService
	{
		public decimal CalculateMatchGrade(JobApplication jobApplication, bool calculateForCriticalCompetences)
		{
			if (!jobApplication.Candidate.Competences.Any() ||
				!jobApplication.Job.JobCompetences.Where(comp => comp.IsCritical == calculateForCriticalCompetences).Any())
				return 0;

			List<Competence> userCompetences = jobApplication.Candidate.Competences;
			List<JobCompetence> jobCompetences = calculateForCriticalCompetences 
				? jobApplication.Job.JobCompetences.Where(comp => comp.IsCritical).ToList()
				: jobApplication.Job.JobCompetences.Where(comp => !comp.IsCritical).ToList();

			int totalRequiredCompetences = jobCompetences.Count;
			int matchingCompetences = jobCompetences
				.Count(jobCompetence => userCompetences.Any(userCompetence => userCompetence.CompetenceId == jobCompetence.CompetenceId));

			return ((decimal)matchingCompetences / totalRequiredCompetences) * 100;
		}
	}
}

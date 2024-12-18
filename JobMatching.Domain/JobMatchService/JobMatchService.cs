using JobMatching.Domain.Entities.Candidate;
using JobMatching.Domain.Entities.Competence;
using JobMatching.Domain.Entities.Job;
using JobMatching.Domain.JobMatchService;
using System.Dynamic;

namespace JobMatching.Domain.JobMatchGradeService
{
    public class JobMatchService : IJobMatchService
    {
        public decimal CalculateOverallMatchGrade(
            List<JobCompetence> jobCompetences,
            List<CandidateCompetence> applicantCompetences)
        {
            if (!ValidateCompetencesAreNotEmpty(jobCompetences, applicantCompetences))
                return 0;

            int totalCompetencesCount = jobCompetences.Count;
            int matchingCompetences = CalculateMatchingCompetences(applicantCompetences, jobCompetences);

            return ((decimal)matchingCompetences / totalCompetencesCount) * 100;
        }

        public List<CriticalCompetenceMatch> GetCriticalCompetencesMatchSummary(
            List<JobCompetence> jobCriticalCompetences,
            List<CandidateCompetence> applicantCompetences)
        {
            var criticalCompetencesMatchSummary = new List<CriticalCompetenceMatch>();

            if (!ValidateCompetencesAreNotEmpty(jobCriticalCompetences, applicantCompetences))
                return jobCriticalCompetences
                    .Select(jobComp => new CriticalCompetenceMatch(jobComp.CompetenceName, false)).ToList();

            foreach (var jobComp in jobCriticalCompetences)
            {
                if (applicantCompetences.Any(appComp => appComp.Equals(jobComp)))
                {
                    criticalCompetencesMatchSummary.Add(new CriticalCompetenceMatch(jobComp.CompetenceName, true));
                }
                criticalCompetencesMatchSummary.Add(new CriticalCompetenceMatch(jobComp.CompetenceName, false));
            }

            return criticalCompetencesMatchSummary;
        } 

        private int CalculateMatchingCompetences(List<CandidateCompetence> applicantCompetences, List<JobCompetence> jobCompetences) =>
            jobCompetences.Count(jobCompetence => applicantCompetences
                .Any(applicantCompetence => applicantCompetence.CompetenceId == jobCompetence.CompetenceId));

        private bool ValidateCompetencesAreNotEmpty(
            List<JobCompetence> jobCompetences,
            List<CandidateCompetence> applicantCompetences)
        {
            if (!jobCompetences.Any() ||
                !applicantCompetences.Any())
            {
                return false;
            }
            return true;
        }
    }
}

using JobMatching.Domain.Entities.Candidate;
using JobMatching.Domain.Entities.Job;

namespace JobMatching.Domain.DomainServices.CriticalCompetencesMatchService
{
    public sealed class CriticalCompetenceMatchService : ICriticalCompetencesMatchService
    {
        public List<CriticalCompetenceMatch> GetCriticalCompetencesMatch(
            IEnumerable<JobCompetence> jobCriticalCompetences,
            IEnumerable<CandidateCompetence> applicantCompetences)
        {
            var criticalCompetencesMatchSummary = new List<CriticalCompetenceMatch>();

            if (!ValidateCompetencesAreNotEmpty(jobCriticalCompetences, applicantCompetences))
            {
                return jobCriticalCompetences
                    .Select(jobComp =>
                        new CriticalCompetenceMatch(
                            jobComp.CompetenceName,
                            false))
                    .ToList();
            }

            return jobCriticalCompetences
                .Select(jc => applicantCompetences
                .Any(ac => ac.Equals(jc))
                    ? new CriticalCompetenceMatch(jc.CompetenceName, true)
                    : new CriticalCompetenceMatch(jc.CompetenceName, false))
                .ToList();
        }

        private bool ValidateCompetencesAreNotEmpty(
            IEnumerable<JobCompetence> jobCompetences,
            IEnumerable<CandidateCompetence> applicantCompetences)
        {
            return jobCompetences.Any() && applicantCompetences.Any();
        }
    }
}

using JobMatching.Domain.Domain.Candidate.Entities;
using JobMatching.Domain.Domain.Job.Entities;

namespace JobMatching.Domain.DomainServices.OverallMatchGradeService
{
    public sealed class OverallMatchGradeService : IOverallMatchGradeService
    {
        public decimal CalculateOverallMatchGrade(
            IEnumerable<JobCompetence> jobCompetences,
            IEnumerable<CandidateCompetence> applicantCompetences)
        {
            if (!ValidateCompetencesAreNotEmpty(jobCompetences, applicantCompetences))
                return 0;

            int jobCompetencesCount = jobCompetences.Count();
            int matchingCompetences = CountCandidateMatchingCompetences(applicantCompetences, jobCompetences);

            return (decimal)matchingCompetences / jobCompetencesCount * 100;
        }

        private int CountCandidateMatchingCompetences(
            IEnumerable<CandidateCompetence> applicantCompetences,
            IEnumerable<JobCompetence> jobCompetences)
        {
            return jobCompetences.Count(jobCompetence => applicantCompetences
                .Any(applicantCompetence => applicantCompetence.CompetenceId == jobCompetence.CompetenceId));
        }

        private bool ValidateCompetencesAreNotEmpty(
            IEnumerable<JobCompetence> jobCompetences,
            IEnumerable<CandidateCompetence> applicantCompetences)
        {
            return jobCompetences.Any() && applicantCompetences.Any();
        }
    }
}

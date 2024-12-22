using JobMatching.Domain.Entities.Candidate;
using JobMatching.Domain.Entities.Job;

namespace JobMatching.Domain.DomainServices.CriticalCompetencesMatchService
{
    public interface ICriticalCompetencesMatchService
    {
        List<CriticalCompetenceMatch> GetCriticalCompetencesMatch(
            IEnumerable<JobCompetence> jobCriticalCompetences,
            IEnumerable<CandidateCompetence> applicantCompetences);
    }
}

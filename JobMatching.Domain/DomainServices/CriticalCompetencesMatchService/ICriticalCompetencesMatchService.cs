using JobMatching.Domain.Domain.Candidate.Entities;
using JobMatching.Domain.Domain.Job.Entities;

namespace JobMatching.Domain.DomainServices.CriticalCompetencesMatchService
{
    public interface ICriticalCompetencesMatchService
    {
        List<CriticalCompetenceMatch> GetCriticalCompetencesMatch(
            IEnumerable<JobCompetence> jobCriticalCompetences,
            IEnumerable<CandidateCompetence> applicantCompetences);
    }
}

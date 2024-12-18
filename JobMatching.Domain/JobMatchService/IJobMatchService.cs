using JobMatching.Domain.Entities.Candidate;
using JobMatching.Domain.Entities.Competence;
using JobMatching.Domain.Entities.Job;
using JobMatching.Domain.JobMatchService;

namespace JobMatching.Domain.JobMatchGradeService
{
    public interface IJobMatchService
    {
        decimal CalculateOverallMatchGrade(
            List<JobCompetence> jobCompetences,
            List<CandidateCompetence> applicantCompetences);
        List<CriticalCompetenceMatch> GetCriticalCompetencesMatchSummary(
            List<JobCompetence> jobCriticalCompetences,
            List<CandidateCompetence> applicantCompetences);
    }
}

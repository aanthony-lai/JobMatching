using JobMatching.Domain.Entities.Candidate;
using JobMatching.Domain.Entities.Job;

namespace JobMatching.Domain.DomainServices.OverallMatchGradeService
{
    public interface IOverallMatchGradeService
    {
        decimal CalculateOverallMatchGrade(
            IEnumerable<JobCompetence> jobCompetences,
            IEnumerable<CandidateCompetence> applicantCompetences);
    }
}

using JobMatching.Domain.Domain.Candidate.Entities;
using JobMatching.Domain.Domain.Job.Entities;

namespace JobMatching.Domain.DomainServices.OverallMatchGradeService
{
    public interface IOverallMatchGradeService
    {
        decimal CalculateOverallMatchGrade(
            IEnumerable<JobCompetence> jobCompetences,
            IEnumerable<CandidateCompetence> applicantCompetences);
    }
}

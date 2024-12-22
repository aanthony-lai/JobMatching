using JobMatching.Application.Applicants.GetApplicants;
using JobMatching.Domain.DomainServices.CriticalCompetencesMatchService;
using JobMatching.Domain.Entities.Candidate;

namespace JobMatching.Application.Applicants
{
    public interface IApplicantMapper
    {
        ApplicantMatchSummaryDTO ToApplicantMatchSummaryDto(
            Candidate applicant,
            IReadOnlyList<CriticalCompetenceMatch> matchingJobCriticalCompetences,
            decimal overallMatchGrade);
    }
}

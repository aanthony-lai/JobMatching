using JobMatching.Application.Applicants.GetApplicants;
using JobMatching.Domain.Domain.Candidate.Entities;
using JobMatching.Domain.DomainServices.CriticalCompetencesMatchService;

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

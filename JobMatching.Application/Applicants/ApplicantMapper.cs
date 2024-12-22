using JobMatching.Application.Applicants.GetApplicants;
using JobMatching.Domain.DomainServices.CriticalCompetencesMatchService;
using JobMatching.Domain.Entities.Candidate;

namespace JobMatching.Application.Applicants
{
    public sealed class ApplicantMapper : IApplicantMapper
    {
        public ApplicantMatchSummaryDTO ToApplicantMatchSummaryDto(
            Candidate applicant,
            IReadOnlyList<CriticalCompetenceMatch> matchingJobCriticalCompetences,
            decimal overallMatchGrade)
        {
            return new ApplicantMatchSummaryDTO(
                applicant.Id,
                applicant.Name.FullName,
                applicant.CandidateCompetences
                    .Select(c => c.CompetenceName)
                    .ToList(),
                matchingJobCriticalCompetences,
                overallMatchGrade);
        }
    }
}

using JobMatching.Application.Applicants.GetApplicants;
using JobMatching.Domain.Domain.Candidate.Entities;
using JobMatching.Domain.DomainServices.CriticalCompetencesMatchService;

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
                applicant.Competences
                    .Select(c => c.CompetenceName)
                    .ToList(),
                matchingJobCriticalCompetences,
                overallMatchGrade);
        }
    }
}

using JobMatching.Domain.DomainServices.CriticalCompetencesMatchService;

namespace JobMatching.Application.Applicants.GetApplicants
{
    public sealed record ApplicantMatchSummaryDTO(
        Guid ApplicantId,
        string Name,
        IReadOnlyList<string> AllCompetences,
        IReadOnlyList<CriticalCompetenceMatch> JobCriticalCompetencesMatch,
        decimal OverallMatchGrade);
}

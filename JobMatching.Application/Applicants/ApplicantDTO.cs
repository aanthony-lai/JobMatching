using JobMatching.Domain.JobMatchService;

namespace JobMatching.Application.Applicants
{
    public record ApplicantDTO(
        Guid ApplicantId,
        string FullName,
        IReadOnlyList<string> Competences,
        IReadOnlyList<CriticalCompetenceMatch> MatchedCriticalCompetences,
        decimal MatchGrade);
}

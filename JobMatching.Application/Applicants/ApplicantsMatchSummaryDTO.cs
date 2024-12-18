namespace JobMatching.Application.Applicants
{
    public record ApplicantsMatchSummaryDTO(
        Guid JobId,
        string JobTitle,
        IReadOnlyList<string> PreferredCompetences,
        IReadOnlyList<string> CriticalCompetences,
        IReadOnlyList<ApplicantDTO> Applicants);
}

namespace JobMatching.Application.Applicants.GetApplicants
{
    public sealed record CriticalCompetenceMatchDTO(
        string CompetenceName,
        bool IsMatch);
}

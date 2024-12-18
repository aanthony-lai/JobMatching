namespace JobMatching.Application.DTO.Job
{
    public record JobDTO(
        Guid JobId,
        string Title,
        string? JobDescription,
        int? MaxSalary,
        int? MinSalary,
        IReadOnlyList<Guid> PreferredCompetences,
        IReadOnlyList<Guid> CriticalCompetences,
        IReadOnlyList<Guid> Applicants,
        Guid EmployerId);
}

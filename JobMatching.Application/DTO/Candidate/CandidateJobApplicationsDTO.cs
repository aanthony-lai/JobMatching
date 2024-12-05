namespace JobMatching.Application.DTO.Candidate
{
    public record CandidateJobApplicationsDTO(
        Guid JobApplicationId,
        string EmployerName,
        string JobTitle);
}

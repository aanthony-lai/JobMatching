namespace JobMatching.Application.DTO.Employer
{
    public record EmployerDTO(
        string Name,
        List<Guid> Jobs);
}

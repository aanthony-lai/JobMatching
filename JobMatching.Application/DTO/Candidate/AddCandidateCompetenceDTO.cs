namespace JobMatching.Application.DTO.Candidate
{
    public record AddCandidateCompetenceDTO(
        Guid candidateId,
        Guid competenceId);
}

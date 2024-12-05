using JobMatching.Application.DTO.Candidate;
using JobMatching.Application.DTO.Shared;
using JobMatching.Domain.Entities.JunctionEntities;

namespace JobMatching.Application.DTO.JobApplication
{
    public record JobApplicationCandidateDTO(
        Guid CandidateId,
        string FirstName,
        string LastName,
        List<CompetenceDTO> Competences,
        List<CandidateLanguageDTO> Languages,
        bool? HasDriversLicense);
}

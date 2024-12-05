using JobMatching.Application.DTO.Candidate;

namespace JobMatching.Application.DTO.JobApplication
{
    public record JobApplicationCandidateDTO(
        Guid CandidateId,
        string FirstName,
        string LastName,
        string[] Competences,
        List<CandidateLanguageDTO> Languages,
        bool? HasDriversLicense);
}

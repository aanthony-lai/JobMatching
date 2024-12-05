using JobMatching.Application.DTO.Shared;

namespace JobMatching.Application.DTO.Candidate
{
    public record CandidateDTO(
        Guid CandidateId,
        string FirstName,
        string LastName,
        //List<CompetenceDTO> Competences,
        string[] Competences,
        List<CandidateJobApplicationsDTO> JobApplications,
        List<CandidateLanguageDTO> Languages,
        bool? HasDriversLicense);
}

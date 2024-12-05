namespace JobMatching.Application.DTO.Candidate
{
    public record CandidateDTO(
        Guid CandidateId,
        string FirstName,
        string LastName,
        string[] Competences,
        List<CandidateJobApplicationsDTO> JobApplications,
        List<CandidateLanguageDTO> Languages,
        bool? HasDriversLicense);
}

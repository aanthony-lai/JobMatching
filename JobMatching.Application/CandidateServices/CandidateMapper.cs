using JobMatching.Application.DTO.Candidate;
using JobMatching.Domain.Domain.Candidate.Entities;

namespace JobMatching.Application.CandidateServices
{
    public class CandidateMapper : ICandidateMapper
    {
        public CandidateDTO ToCandidateDto(Candidate domainCandidate) =>
            new CandidateDTO(
                Id: domainCandidate.Id,
                FullName: domainCandidate.Name.ToString(),
                JobApplicationIds: domainCandidate.Applications.Select(j => j.JobApplicationId),
                LanguageIds: domainCandidate.LanguageIds.Select(l => l),
                CompetenceIds: domainCandidate.Competences.Select(c => c.CompetenceId));
    }
}

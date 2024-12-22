using JobMatching.Application.DTO.Candidate;
using JobMatching.Domain.Entities.Candidate;

namespace JobMatching.Application.Candidates
{
    public interface ICandidateMapper
    {
        CandidateDTO ToCandidateDto(Candidate candidate);
    }
}

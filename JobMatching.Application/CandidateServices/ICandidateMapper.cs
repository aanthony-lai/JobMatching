using JobMatching.Application.DTO.Candidate;
using JobMatching.Domain.Entities.Candidate;

namespace JobMatching.Application.CandidateServices
{
    public interface ICandidateMapper
    {
        CandidateDTO ToCandidateDto(Candidate candidate);
    }
}

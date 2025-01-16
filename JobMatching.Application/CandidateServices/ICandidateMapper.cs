using JobMatching.Application.DTO.Candidate;
using JobMatching.Domain.Domain.Candidate.Entities;

namespace JobMatching.Application.CandidateServices
{
    public interface ICandidateMapper
    {
        CandidateDTO ToCandidateDto(Candidate candidate);
    }
}

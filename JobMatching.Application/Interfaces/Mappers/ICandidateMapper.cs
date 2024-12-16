using JobMatching.Application.DTO.Candidate;
using JobMatching.Domain.Entities.Candidate;

namespace JobMatching.Application.Interfaces.Mappers
{
    public interface ICandidateMapper
    {
        CandidateDTO ToDto(Candidate candidate);
    }
}

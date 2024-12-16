using JobMatching.Application.DTO.Candidate;
using JobMatching.Common.Results;
using JobMatching.Domain.Entities.Candidate;

namespace JobMatching.Application.Interfaces.Services;

public interface ICandidateService
{
    Task<List<CandidateDTO>> GetAsync();
    Task<Result<CandidateDTO>> GetByIdAsync(Guid candidateId);
    Task<Result<Candidate>> AddAsync(CreateCandidateDTO candidateDto);
}
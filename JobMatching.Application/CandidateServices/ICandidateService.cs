using JobMatching.Application.DTO.Candidate;
using JobMatching.Common.Results;
using JobMatching.Domain.Entities.User;

namespace JobMatching.Application.CandidateServices;

public interface ICandidateService
{
    Task<List<CandidateDTO>> GetAsync();
    Task<Result<CandidateDTO>> GetByIdAsync(Guid candidateId);
    Task<Result> CreateAsync(User domainUser);
}
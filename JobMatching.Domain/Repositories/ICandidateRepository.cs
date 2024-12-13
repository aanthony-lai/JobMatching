using JobMatching.Domain.Entities.Candidate;

namespace JobMatching.Domain.Repositories;

public interface ICandidateRepository
{
    Task<List<Candidate>> GetAsync(bool withTracking);
    Task<Candidate?> GetByIdAsync(Guid candidateId, bool withTracking);
    Task<bool> SaveAsync(Candidate candidate);
    Task<bool> UpdateAsync(Candidate candidate);
}
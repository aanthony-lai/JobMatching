using JobMatching.Domain.Entities.Candidate;

namespace JobMatching.Domain.Repositories;

public interface ICandidateRepository
{
    Task<List<Candidate>> GetAsync(bool withTracking = false);
    Task<Candidate?> GetByIdAsync(Guid candidateId, bool withTracking = false);
    Task<List<Candidate>> GetByIdsAsync(IEnumerable<Guid> ids, bool withTracking = false);
    Task SaveAsync(Candidate candidate);
    Task UpdateAsync(Candidate candidate);
}
using JobMatching.Domain.Domain.Candidate.Entities;

namespace JobMatching.Domain.Repositories;

public interface ICandidateRepository
{
    Task<IEnumerable<Candidate>> GetAsync(bool withTracking = false);
    Task<Candidate?> GetByIdAsync(Guid candidateId, bool withTracking = false);
    Task SaveAsync(Candidate candidate);
    Task SaveAsync();
}
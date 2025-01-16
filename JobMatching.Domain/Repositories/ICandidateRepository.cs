using JobMatching.Common.Results;
using JobMatching.Domain.Domain.Candidate.Entities;

namespace JobMatching.Domain.Repositories;

public interface ICandidateRepository
{
    Task<ICollection<Candidate>> GetAsync(bool withTracking = false);
    Task<Candidate?> GetByIdAsync(Guid candidateId, bool withTracking = false);
    Task SaveAsync(Candidate candidate);
    Task SaveAsync();

    //Task<IEnumerable<Candidate>> GetByIdsAsync(IEnumerable<Guid> ids, bool withTracking = false);
}
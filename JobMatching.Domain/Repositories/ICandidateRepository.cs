using JobMatching.Domain.Entities;
using JobMatching.Domain.Entities.JunctionEntities;

namespace JobMatching.Domain.Repositories;

public interface ICandidateRepository
{
	Task<Candidate?> GetByIdAsync(Guid userId, bool withTracking = true);
	Task<List<Candidate>> GetAllAsync(bool withTracking = true);
	Task AddAsync(Candidate candidate);
	Task<CandidateLanguage> AddCandidateLanguageAsync(CandidateLanguage candidateLanguage);
    Task UpdateAsync(Candidate candidate);
	Task<bool> ExistsAsync(Guid candidateId);
}
using JobMatching.Domain.Entities;

namespace JobMatching.Application.Interfaces;

public interface ICandidateRepository
{
	Task<Candidate?> GetCandidateByIdAsync(Guid userId, bool withTracking = true);
	Task<List<Candidate>> GetCandidatesAsync(bool withTracking = true);
	Task SaveCandidateAsync(Candidate candidate);
	Task UpdateCandidateAsync(Candidate candidate);
	Task<bool> CandidateExistsAsync(Guid candidateId);
}
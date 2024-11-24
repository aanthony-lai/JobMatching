using JobMatching.Domain.Entities;
using System.Runtime.InteropServices;

namespace JobMatching.Application.Interfaces;

public interface ICandidateRepository
{
    Task<Candidate?> GetCandidateByIdAsync(Guid userId, bool withTracking = true);
    Task<List<Candidate>> GetCandidatesAsync(bool withTracking = true);
    Task UpdateCandidateAsync(Candidate user);
    Task<bool> CandidateExistsAsync(Guid candidateId);
}
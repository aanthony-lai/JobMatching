using JobMatching.Application.DTO.Candidate;
using JobMatching.Common.Results;
using JobMatching.Domain.Entities;
using JobMatching.Domain.Entities.JunctionEntities;

namespace JobMatching.Application.Interfaces;

public interface ICandidateService
{
    Task<Result<CandidateDTO>> GetByIdAsync(Guid candidateId);
    Task<List<CandidateDTO>> GetCandidatesAsync();
    Task<Result<Candidate>> AddAsync(CreateCandidateDTO dto);
    Task AddCandidateCompetence(Guid candidateId, AddCandidateCompetenceDTO dto);
    Task<Result<CandidateLanguage>> AddCandidateLanguageAsync(Guid candidateId, AddCandidateLanguageDTO dto);
    Task<bool> ExistsAsync(Guid candidateId);
}

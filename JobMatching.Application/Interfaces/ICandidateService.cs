using JobMatching.Application.DTO.Candidate;

namespace JobMatching.Application.Interfaces;

public interface ICandidateService 
{
	Task<CandidateDTO?> GetCandidateByIdAsync(Guid userId);
	Task<List<CandidateDTO>> GetCandidatesAsync();
	Task CreateCandidateAsync(CreateCandidateDTO candidateDto);
	Task AddCandidateCompetence(AddCandidateCompetenceDTO addUserCompetenceDto);
	Task<bool> CandidateExistsAsync(Guid candidateId);
}

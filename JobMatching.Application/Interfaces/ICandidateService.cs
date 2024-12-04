using JobMatching.Application.DTO.Candidate;
using JobMatching.Application.DTO.JobApplication;

namespace JobMatching.Application.Interfaces;

public interface ICandidateService 
{
	Task<CandidateDTO?> GetCandidateByIdAsync(Guid userId);
	Task<List<CandidateDTO>> GetCandidatesAsync();
	Task CreateCandidateAsync(CreateCandidateDTO createCandidateDto);
	Task AddCandidateCompetence(AddCandidateCompetenceDTO addUserCompetenceDto);
	Task AddCandidateLanguageAsync(AddCandidateLanguageDTO addCandidateLanguageDTO);
	Task<bool> CandidateExistsAsync(Guid candidateId);
}

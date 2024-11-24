using JobMatching.Application.DTO.Candidate;
using JobMatching.Application.Exceptions;
using JobMatching.Application.Interfaces;
using JobMatching.Application.Utilities;
using JobMatching.Domain.Entities;

namespace JobMatching.Application.Services
{
	public class CandidateService : ICandidateService
	{
		private readonly ICandidateRepository _candidateRepository;
		private readonly ICompetenceRepository _competenceRepository;

		public CandidateService(
			ICandidateRepository candidateRepository,
			ICompetenceRepository competenceRepository)
		{
			_candidateRepository = candidateRepository;
			_competenceRepository = competenceRepository;
		}

		public async Task<CandidateDTO?> GetCandidateByIdAsync(Guid candidateId)
		{
			var candidate = await _candidateRepository.GetCandidateByIdAsync(candidateId, withTracking: false);
			if (candidate == null)
				return null;

			return CandidateMapper.MapCandidate(candidate);
		}

		public async Task<List<CandidateDTO>> GetCandidatesAsync()
		{
			var candidates = await _candidateRepository.GetCandidatesAsync(withTracking: false);
			return CandidateMapper.MapCandidates(candidates);
		}

		public async Task AddCandidateCompetence(AddCandidateCompetenceDTO addCandidateCompetenceDto)
		{
			Candidate candidate = await _candidateRepository.GetCandidateByIdAsync(addCandidateCompetenceDto.candidateId)
				?? throw new CandidateNotFoundException($"Candidate with ID {addCandidateCompetenceDto.candidateId} was not found.");

			Competence competence = await _competenceRepository.GetCompetenceByIdAsync(addCandidateCompetenceDto.competenceId)
				?? throw new CompetenceNotFoundException($"Competence with ID {addCandidateCompetenceDto.competenceId} was not found.");

			candidate.AddCompetence(competence);
			await _candidateRepository.UpdateCandidateAsync(candidate);
		}

		public async Task<bool> CandidateExistsAsync(Guid candidateId) =>
			await _candidateRepository.CandidateExistsAsync(candidateId);
	}
}

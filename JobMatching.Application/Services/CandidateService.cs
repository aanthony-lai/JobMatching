using JobMatching.Application.DTO.Candidate;
using JobMatching.Application.Exceptions;
using JobMatching.Application.Interfaces;
using JobMatching.Application.Utilities;
using JobMatching.Common.SystemMessages.CandidateMessages;
using JobMatching.Common.SystemMessages.CompetenceMessages;
using JobMatching.Domain.Entities;
using JobMatching.Domain.Entities.JunctionEntities;
using JobMatching.Domain.Types;

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

		public async Task CreateCandidateAsync(CreateCandidateDTO createCandidateDto)
		{
			await _candidateRepository.SaveCandidateAsync(
				new Candidate(
					createCandidateDto.FirstName,
					createCandidateDto.LastName,
					createCandidateDto.Email,
					createCandidateDto.HasDriversLicense));
		}

		public async Task AddCandidateCompetence(AddCandidateCompetenceDTO addCandidateCompetenceDto)
		{
			Candidate candidate = await _candidateRepository.GetCandidateByIdAsync(addCandidateCompetenceDto.candidateId)
				?? throw new CandidateNotFoundException(CandidateMessages.CandidateNotFound(addCandidateCompetenceDto.candidateId));

			Competence competence = await _competenceRepository.GetCompetenceByIdAsync(addCandidateCompetenceDto.competenceId)
				?? throw new CompetenceNotFoundException(CompetenceMessages.CompetenceDoesNotExist(addCandidateCompetenceDto.competenceId));

			candidate.AddCompetence(competence);
			await _candidateRepository.UpdateCandidateAsync(candidate);
		}

		public async Task AddCandidateLanguageAsync(AddCandidateLanguageDTO addCandidateLanguageDTO)
		{
			var candidate = await _candidateRepository.GetCandidateByIdAsync(addCandidateLanguageDTO.CandidateId)
				?? throw new CandidateNotFoundException("Candidate not found.");

			candidate.AddLanguageAndProficiency(
				new CandidateLanguage(candidate.Id, addCandidateLanguageDTO.LanguageId, addCandidateLanguageDTO.ProficiencyLevel));

			await _candidateRepository.UpdateCandidateAsync(candidate);
		}

		public async Task<bool> CandidateExistsAsync(Guid candidateId) =>
			await _candidateRepository.CandidateExistsAsync(candidateId);
	}
}

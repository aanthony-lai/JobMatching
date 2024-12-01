using JobMatching.Application.DTO.Candidate;
using JobMatching.Application.Exceptions;
using JobMatching.Application.Interfaces;
using JobMatching.Application.Utilities;
using JobMatching.Common.SystemMessages.CandidateMessages;
using JobMatching.Common.SystemMessages.CompetenceMessages;
using JobMatching.Domain.Entities;

namespace JobMatching.Application.Services
{
	public class CandidateService : ICandidateService
	{
		private readonly ICandidateRepository _candidateRepository;
		private readonly ICompetenceRepository _competenceRepository;
		private readonly IJobRepository _jobRepository;

		public CandidateService(
			ICandidateRepository candidateRepository,
			ICompetenceRepository competenceRepository,
			IJobRepository jobRepository)
		{
			_candidateRepository = candidateRepository;
			_competenceRepository = competenceRepository;
			_jobRepository = jobRepository;
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

		public async Task CreateCandidateAsync(CreateCandidateDTO candidateDto)
		{
			await _candidateRepository.SaveCandidateAsync(
				new Candidate(
					candidateDto.FirstName,
					candidateDto.LastName,
					candidateDto.Email));
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

		public async Task<bool> CandidateExistsAsync(Guid candidateId) =>
			await _candidateRepository.CandidateExistsAsync(candidateId);
	}
}

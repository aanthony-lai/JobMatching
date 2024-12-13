using JobMatching.Application.DTO.Candidate;
using JobMatching.Application.Interfaces;
using JobMatching.Application.Utilities;
using JobMatching.Common.Results;
using JobMatching.Common.SystemMessages.CandidateMessages;
using JobMatching.Common.SystemMessages.CompetenceMessages;
using JobMatching.Domain.Entities.Candidate;
using JobMatching.Domain.Errors;
using JobMatching.Domain.Repositories;

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

        public async Task<Result<CandidateDTO>> GetByIdAsync(Guid candidateId)
        {
            var candidate = await _candidateRepository.GetByIdAsync(candidateId, withTracking: false);
            if (candidate is null)
                return Result<CandidateDTO>.Failure(CandidateErrors.NotFound);

            return Result<CandidateDTO>.Success(CandidateMapper.MapCandidate(candidate));
        }

        public async Task<List<CandidateDTO>> GetCandidatesAsync()
        {
            var candidates = await _candidateRepository.GetAllAsync(withTracking: false);
            return CandidateMapper.MapCandidates(candidates);
        }

        public async Task<Result<Candidate>> AddAsync(CreateCandidateDTO dto)
        {
            Result<Candidate> result = Candidate.Create(
                dto.FirstName,
                dto.LastName,
                dto.Email,
                dto.HasDriversLicense);

            if (!result.IsSuccess)
                return Result<Candidate>.Failure(result.Error);

            await _candidateRepository.AddAsync(result.Value);

            return Result<Candidate>.Success(result.Value);
        }

        public async Task AddCandidateCompetence(Guid candidateId, AddCandidateCompetenceDTO dto)
        {
            Candidate candidate = await _candidateRepository.GetByIdAsync(candidateId)
                ?? throw new EntityNotFoundException(CandidateMessages.CandidateNotFound(candidateId));

            Competence competence = await _competenceRepository.GetByIdAsync(dto.competenceId)
                ?? throw new EntityNotFoundException(CompetenceMessages.CompetenceDoesNotExist(dto.competenceId));

            candidate.AddCompetence(competence);
            await _candidateRepository.UpdateAsync(candidate);
        }

        public async Task<Result<CandidateLanguage>> AddCandidateLanguageAsync(Guid candidateId, AddCandidateLanguageDTO dto)
        {
            if (!await _candidateRepository.ExistsAsync(candidateId))
                return Result<CandidateLanguage>.Failure(CandidateErrors.NotFound);

            var candidateLanguage = new CandidateLanguage(
                candidateId, dto.LanguageId, dto.ProficiencyLevel);

            await _candidateRepository.AddCandidateLanguageAsync(candidateLanguage);
            return Result<CandidateLanguage>.Success(candidateLanguage);
        }

        public async Task<bool> ExistsAsync(Guid candidateId) =>
            await _candidateRepository.ExistsAsync(candidateId);
    }
}

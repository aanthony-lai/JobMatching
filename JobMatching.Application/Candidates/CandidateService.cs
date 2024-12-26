﻿using JobMatching.Application.DTO.Candidate;
using JobMatching.Common.Results;
using JobMatching.Domain.Entities.Candidate;
using JobMatching.Domain.Errors;
using JobMatching.Domain.Repositories;

namespace JobMatching.Application.Candidates
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly ICandidateMapper _candidateMapper;

        public CandidateService(
            ICandidateRepository candidateRepository,
            ICandidateMapper candidateMapper)
        {
            _candidateRepository = candidateRepository;
            _candidateMapper = candidateMapper;
        }

        public async Task<List<CandidateDTO>> GetAsync()
        {
            var candidates = await _candidateRepository.GetAsync();

            return candidates
                .Select(candidate => _candidateMapper
                .ToCandidateDto(candidate))
                .ToList();
        }

        public async Task<Result<CandidateDTO>> GetByIdAsync(Guid candidateId)
        {
            var candidate = await _candidateRepository.GetByIdAsync(candidateId);

            if (candidate is null)
                return Result<CandidateDTO>.Failure(CandidateErrors.NotFound(candidateId));

            var candidateDto = _candidateMapper.ToCandidateDto(candidate);

            return Result<CandidateDTO>.Success(candidateDto);
        }

        public async Task<Result<Candidate>> AddAsync(CreateCandidateDTO candidateDto)
        {
            var candidateResult = Candidate.Create(
                candidateDto.FirstName,
                candidateDto.LastName);

            if (!candidateResult.IsSuccess)
                return Result<Candidate>.Failure(candidateResult.Error);

            await _candidateRepository.SaveAsync(candidateResult.Value);

            return Result<Candidate>.Success(candidateResult.Value);
        }
    }
}
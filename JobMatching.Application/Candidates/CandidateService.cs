using JobMatching.Application.DTO.Candidate;
using JobMatching.Common.Results;
using JobMatching.Domain.Authentication;
using JobMatching.Domain.Entities.Candidate;
using JobMatching.Domain.Errors;
using JobMatching.Domain.Repositories;

namespace JobMatching.Application.Candidates
{
    public class CandidateService(
        ICandidateRepository candidateRepository,
        ICandidateMapper candidateMapper) : ICandidateService
    {
        public async Task<List<CandidateDTO>> GetAsync()
        {
            var candidates = await candidateRepository.GetAsync();

            return candidates
                .Select(candidate => candidateMapper
                .ToCandidateDto(candidate))
                .ToList();
        }

        public async Task<Result<CandidateDTO>> GetByIdAsync(Guid candidateId)
        {
            var candidate = await candidateRepository.GetByIdAsync(candidateId);

            if (candidate is null)
                return Result<CandidateDTO>.Failure(CandidateErrors.NotFound(candidateId));

            var candidateDto = candidateMapper.ToCandidateDto(candidate);

            return Result<CandidateDTO>.Success(candidateDto);
        }

        public async Task<Result> CreateAsync(DomainUser domainUser)
        {
            var createCandidateResult = Candidate.Create(
                domainUser.FirstName,
                domainUser.LasName,
                Guid.Parse(domainUser.Id));

            if (!createCandidateResult.IsSuccess)
                return Result.Failure(createCandidateResult.Error);

            try
            {
                await candidateRepository.AddAsync(createCandidateResult.Value);
                return Result.Success();
            }
            catch (Exception)
            {
                return Result.Failure(new Error("An error occurred, while trying to create the profile."));
            }
        }
    }
}

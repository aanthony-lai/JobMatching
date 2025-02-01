using JobMatching.Application.DTO.Candidate;
using JobMatching.Common.Results;
using JobMatching.Domain.Domain.Candidate.Entities;
using JobMatching.Domain.Entities.User;
using JobMatching.Domain.Errors;
using JobMatching.Domain.Repositories;

namespace JobMatching.Application.CandidateServices
{
    public class CandidateService(
        ICandidateRepository candidateRepository,
        ICandidateMapper candidateMapper) : ICandidateService
    {
        public async Task<List<CandidateDTO>> GetAsync()
        {
            var candidates = await candidateRepository.GetAsync();

            return candidates.Select(candidate => 
                candidateMapper.ToCandidateDto(candidate)).ToList();
        }

        public async Task<Result<CandidateDTO>> GetByIdAsync(Guid candidateId)
        {
            var candidate = await candidateRepository.GetByIdAsync(candidateId);

            if (candidate is null)
                return Result<CandidateDTO>.Failure(CandidateErrors.NotFound(candidateId));

            var candidateDto = candidateMapper.ToCandidateDto(candidate);

            return Result<CandidateDTO>.Success(candidateDto);
        }

        public async Task<Result> CreateAsync(User domainUser)
        {
            var candidateUser = Candidate.Create(
                domainUser.CandidateName.FirstName,
                domainUser.CandidateName.LastName,
                domainUser.Id);

            if (!candidateUser.IsSuccess)
                return Result.Failure(candidateUser.Error);

            await candidateRepository.SaveAsync(candidateUser.Value);
            return Result.Success();
        }
    }
}

using JobMatching.Application.DTO.Employer;
using JobMatching.Application.Interfaces.Mappers;
using JobMatching.Application.Interfaces.Services;
using JobMatching.Common.Results;
using JobMatching.Domain.Entities.Employer;
using JobMatching.Domain.Entities.User;
using JobMatching.Domain.Errors;
using JobMatching.Domain.Repositories;

namespace JobMatching.Application.Services
{
    public class EmployerService(
        IEmployerRepository employerRepository,
        IEmployerMapper employerMapper) : IEmployerService
    {
        public async Task<Result<List<EmployerDTO>>> GetAsync()
        {
            var employers = await employerRepository.GetAsync();

            var employersDto = employers
                .Select(employer => employerMapper
                .MapToEmployerDto(employer))
                .ToList();

            return Result<List<EmployerDTO>>.Success(employersDto);
        }

        public async Task<Result<EmployerDTO>> GetByIdAsync(Guid employerId)
        {
            var employer = await employerRepository.GetByIdAsync(employerId);
            
            if (employer is null)
                return Result<EmployerDTO>.Failure(EmployerErrors.NotFound);

            var employerDto = employerMapper.MapToEmployerDto(employer);

            return Result<EmployerDTO>.Success(employerDto);
        }

        public async Task<Result<List<EmployerDTO>>> GetByNameAsync(string name)
        {
            var employers = await employerRepository.GetByNameAsync(name);

            var employersDto = employers
                .Select(employer => employerMapper
                .MapToEmployerDto(employer))
                .ToList();

            return Result<List<EmployerDTO>>.Success(employersDto);
        }

        public async Task<Result> CreateAsync(DomainUser domainUser)
        {
            var createEmployerResult = Employer.Create(
                domainUser.EmployerName,
                Guid.Parse(domainUser.Id));

            if (!createEmployerResult.IsSuccess)
                return Result.Failure(createEmployerResult.Error);

            try
            {
                await employerRepository.AddAsync(createEmployerResult.Value);
                return Result.Success();
            }
            catch (Exception)
            {
                return Result.Failure(new Error("An error occurred, while trying to create the profile."));
            }
        }
    }
}

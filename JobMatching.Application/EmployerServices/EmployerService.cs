using JobMatching.Application.DTO.Employer;
using JobMatching.Application.Utilities;
using JobMatching.Common.Results;
using JobMatching.Domain.Domain.Employer.Entities;
using JobMatching.Domain.Entities.User;
using JobMatching.Domain.Errors;
using JobMatching.Domain.Repositories;

namespace JobMatching.Application.EmployerServices
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

        public async Task<Result> CreateAsync(User domainUser)
        {
            var domainEmployer = Employer.Create(
                domainUser.EmployerName,
                domainUser.Id);

            if (!domainEmployer.IsSuccess)
                return Result.Failure(domainEmployer.Error);

            try
            {
                await employerRepository.SaveAsync(domainEmployer.Value);
                return Result.Success();
            }
            catch (Exception)
            {
                return Result.Failure(new Error("An error occurred, while trying to create the profile."));
            }
        }
    }
}

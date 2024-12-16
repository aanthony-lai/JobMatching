using JobMatching.Application.DTO.Employer;
using JobMatching.Application.Interfaces.Mappers;
using JobMatching.Application.Interfaces.Services;
using JobMatching.Common.Results;
using JobMatching.Domain.Entities.Employer;
using JobMatching.Domain.Errors;
using JobMatching.Domain.Repositories;

namespace JobMatching.Application.Services
{
    public class EmployerService : IEmployerService
    {
        private readonly IEmployerRepository _employerRepository;
        private readonly IEmployerMapper _employerMapper;

        public EmployerService(
            IEmployerRepository employerRepository,
            IEmployerMapper employerMapper)
        {
            _employerRepository = employerRepository;
            _employerMapper = employerMapper;
        }

        public async Task<Result<List<EmployerDTO>>> GetAsync()
        {
            var employers = await _employerRepository.GetAsync();

            var employersDto = employers
                .Select(employer => _employerMapper
                .ToDto(employer))
                .ToList();

            return Result<List<EmployerDTO>>.Success(employersDto);
        }

        public async Task<Result<EmployerDTO>> GetByIdAsync(Guid employerId)
        {
            var employer = await _employerRepository.GetByIdAsync(employerId);
            
            if (employer is null)
                return Result<EmployerDTO>.Failure(EmployerErrors.NotFound);

            var employerDto = _employerMapper.ToDto(employer);

            return Result<EmployerDTO>.Success(employerDto);
        }

        public async Task<Result<List<EmployerDTO>>> GetByNameAsync(string name)
        {
            var employers = await _employerRepository.GetByNameAsync(name);

            var employersDto = employers
                .Select(employer => _employerMapper
                .ToDto(employer))
                .ToList();

            return Result<List<EmployerDTO>>.Success(employersDto);
        }

        public async Task<Result<Employer>> AddAsync(CreateEmployerDTO createEmployerDto)
        {
            var employerResult = Employer.Create(
                createEmployerDto.Name);
            
            if (!employerResult.IsSuccess)
                return Result<Employer>.Failure(employerResult.Error);

            await _employerRepository.SaveAsync(employerResult.Value);

            return Result<Employer>.Success(employerResult.Value);
        }
    }
}

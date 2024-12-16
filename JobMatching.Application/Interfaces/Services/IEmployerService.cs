using JobMatching.Application.DTO.Employer;
using JobMatching.Common.Results;
using JobMatching.Domain.Entities.Employer;

namespace JobMatching.Application.Interfaces.Services;

public interface IEmployerService
{
    Task<Result<List<EmployerDTO>>> GetAsync();
    Task<Result<EmployerDTO>> GetByIdAsync(Guid employerId);
    Task<Result<List<EmployerDTO>>> GetByNameAsync(string name);
    Task<Result<Employer>> AddAsync(CreateEmployerDTO createEmployerDto);
}
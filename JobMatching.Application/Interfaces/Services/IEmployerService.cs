using JobMatching.Application.DTO.Employer;
using JobMatching.Common.Results;
using JobMatching.Domain.Authentication;

namespace JobMatching.Application.Interfaces.Services;

public interface IEmployerService
{
    Task<Result<List<EmployerDTO>>> GetAsync();
    Task<Result<EmployerDTO>> GetByIdAsync(Guid employerId);
    Task<Result<List<EmployerDTO>>> GetByNameAsync(string name);
    Task<Result> CreateAsync(DomainUser domainUser);
}
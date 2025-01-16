using JobMatching.Application.DTO.Employer;
using JobMatching.Common.Results;
using JobMatching.Domain.Entities.User;

namespace JobMatching.Application.EmployerServices;

public interface IEmployerService
{
    Task<Result<List<EmployerDTO>>> GetAsync();
    Task<Result<EmployerDTO>> GetByIdAsync(Guid employerId);
    Task<Result<List<EmployerDTO>>> GetByNameAsync(string name);
    Task<Result> CreateAsync(User domainUser);
}
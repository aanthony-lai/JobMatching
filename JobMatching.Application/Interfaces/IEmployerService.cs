using JobMatching.Application.DTO.Employer;
using JobMatching.Common.Results;
using JobMatching.Domain.Entities;

namespace JobMatching.Application.Interfaces;

public interface IEmployerService
{
	Task<List<EmployerDTO>> GetAllAsync();
	Task<Result<EmployerDTO>> GetByIdAsync(Guid employerId);
	Task<Result<Employer>> AddAsync(CreateEmployerDTO dto);
}

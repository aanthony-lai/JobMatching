using JobMatching.Application.DTO;
using JobMatching.Domain.Entities;

namespace JobMatching.Application.Interfaces
{
	public interface IEmployerService
	{
		Task<EmployerDTO?> GetEmployerByIdAsync(Guid employerId);
		Task<List<EmployerDTO>> GetEmployersAsync();
	}
}

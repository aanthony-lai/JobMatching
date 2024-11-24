using JobMatching.Application.DTO.Employer;

namespace JobMatching.Application.Interfaces
{
	public interface IEmployerService
	{
		Task<EmployerDTO?> GetEmployerByIdAsync(Guid employerId);
		Task<List<EmployerDTO>> GetEmployersAsync();
	}
}

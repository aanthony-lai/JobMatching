using JobMatching.Domain.Entities;

namespace JobMatching.Application.Interfaces;

public interface IEmployerRepository
{
	Task<Employer?> GetEmployerByIdAsync(Guid employerId, bool withTracking = true);
	Task<List<Employer>> GetEmployersAsync(bool withTracking = true);
	Task SaveEmployerAsync(Employer employer);
}

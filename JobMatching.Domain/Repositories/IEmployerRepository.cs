using JobMatching.Domain.Domain.Employer.Entities;

namespace JobMatching.Domain.Repositories;

public interface IEmployerRepository
{
    Task<List<Employer>> GetAsync(bool withTracking = false);
    Task<Employer?> GetByIdAsync(Guid employerId, bool withTracking = false);
    Task<List<Employer>> GetByNameAsync(string name, bool withTracking = false);
    Task SaveAsync(Employer employer);
}

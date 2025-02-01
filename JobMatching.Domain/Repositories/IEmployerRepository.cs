using JobMatching.Domain.Domain.Employer.Entities;

namespace JobMatching.Domain.Repositories;

public interface IEmployerRepository
{
    Task<IEnumerable<Employer>> GetAsync(bool withTracking = false);
    Task<IEnumerable<Employer>> GetByNameAsync(string name, bool withTracking = false);
    Task<Employer?> GetByIdAsync(Guid employerId, bool withTracking = false);
    Task SaveAsync(Employer employer);
    Task SaveAsync();
}

using JobMatching.Domain.Entities.Employer;

namespace JobMatching.Domain.Repositories;

public interface IEmployerRepository
{
    Task<List<Employer>> GetAsync(bool withTracking);
    Task<Employer?> GetByIdAsync(bool withTracking);
    Task<Employer?> GetByNameAsync(bool withTracking);
    Task<bool> SaveAsync(Employer employer);
    Task<bool> UpdateAsync(Employer employer);
}

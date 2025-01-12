using JobMatching.Infrastructure.DataAccess;
using JobMatching.Infrastructure.QueryExtensions;
using JobMatching.Domain.Entities.Employer;
using JobMatching.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JobMatching.Infrastructure.Repositories
{
    public class EmployerRepository : IEmployerRepository
    {
        private readonly AppDbContext _appDbContext;

        public EmployerRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Employer>> GetAsync(bool withTracking = false)
        {
            return await _appDbContext.Employers
                .AddTracking(withTracking)
                .Include(emp => emp.EmployerJobs)
                .ToListAsync();
        }

        public async Task<Employer?> GetByIdAsync(Guid employerId, bool withTracking = false)
        {
            return await _appDbContext.Employers
                .AddTracking(withTracking)
                .Include(emp => emp.EmployerJobs)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Employer>> GetByNameAsync(string name, bool withTracking = false)
        {
            return await _appDbContext.Employers
                .AddTracking(withTracking)
                .Where(c => c.Name.Contains(name))
                .Include(emp => emp.EmployerJobs)
                .ToListAsync();
        }

        public async Task SaveAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }

        public async Task AddAsync(Employer employer)
        {
            await _appDbContext.Employers.AddAsync(employer);
            await _appDbContext.SaveChangesAsync();
        }
    }
}

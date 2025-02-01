using JobMatching.Infrastructure.DataAccess;
using JobMatching.Domain.Repositories;
using JobMatching.Domain.Domain.Employer.Entities;
using Microsoft.EntityFrameworkCore;
using JobMatching.Infrastructure.QueryExtensions;
using JobMatching.Infrastructure.DataAccess.Entities;

namespace JobMatching.Infrastructure.Repositories
{
    public class EmployerRepository(AppDbContext appDbContext) : IEmployerRepository
    {
        public async Task<IEnumerable<Employer>> GetAsync(bool withTracking = false)
        {
            return await appDbContext.Employers
                .AddTracking(withTracking)
                .Include(e => e.User)
                .Include(e => e.Jobs)
                .Select(e => ToDomain(e))
                .ToListAsync();
        }

        public async Task<IEnumerable<Employer>> GetByNameAsync(string name, bool withTracking = false)
        {
            return await appDbContext.Employers
                .AddTracking(withTracking)
                .Include(e => e.User)
                .Include(e => e.Jobs)
                .Where(e => e.Name.Contains(name))
                .Select(e => ToDomain(e))
                .ToListAsync();
        }

        public async Task<Employer?> GetByIdAsync(Guid id, bool withTracking = false)
        {
            var employer = await appDbContext.Employers
                .AddTracking(withTracking)
                .Include(e => e.User)
                .Include(e => e.Jobs)
                .FirstOrDefaultAsync(e => e.Id == id);
            
            return employer == null 
                ? null : ToDomain(employer);
        }

        public async Task SaveAsync(Employer domainEmployer)
        {
            var employer = ToPersistence(domainEmployer);
            appDbContext.Employers.Update(employer);
            await SaveAsync();
        }

        public async Task SaveAsync() => await appDbContext.SaveChangesAsync();
        
        private Employer ToDomain(EmployerEntity employer) => 
            Employer.Load(employer.Id, employer.Name, employer.UserId);
        
        private EmployerEntity ToPersistence(Employer domainEmployer)
        {
            return new EmployerEntity
            {
                Id = domainEmployer.Id,
                Name = domainEmployer.Name,
                UserId = domainEmployer.UserId,
            };
        }
    }
}

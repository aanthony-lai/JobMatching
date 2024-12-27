using JobMatching.Domain.Entities.Competence;
using JobMatching.Domain.Repositories;
using JobMatching.Infrastructure.Context;
using JobMatching.Infrastructure.QueryExtensions;
using Microsoft.EntityFrameworkCore;

namespace JobMatching.Infrastructure.Repositories
{
    public class CompetenceRepository : ICompetenceRepository
    {
        private readonly AppDbContext _appDbContext;

        public CompetenceRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Competence>> GetAsync(bool withTracking = false)
        {
            return await _appDbContext.Competences
                .AddTracking(withTracking)
                .ToListAsync();
        }

        public async Task<Competence?> GetByIdAsync(Guid competenceId, bool withTracking = false)
        {
            return await _appDbContext.Competences.FirstOrDefaultAsync(comp => comp.Id == competenceId);
        }
    }
}

using JobMatching.DataAccess.Context;
using JobMatching.DataAccess.QueryExtensions;
using JobMatching.Domain.Entities.Competence;
using JobMatching.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JobMatching.DataAccess.Repositories
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

using JobMatching.Domain.Entities.Competence;
using JobMatching.Domain.Repositories;
using JobMatching.Infrastructure.DataAccess;
using JobMatching.Infrastructure.DataAccess.Entities;
using JobMatching.Infrastructure.QueryExtensions;
using Microsoft.EntityFrameworkCore;

namespace JobMatching.Infrastructure.Repositories
{
    public class CompetenceRepository(AppDbContext appDbContext) : ICompetenceRepository
    {
        public async Task<IEnumerable<Competence>> GetAsync(bool withTracking = false)
        {
            return await appDbContext.Competences
                .AddTracking(withTracking)
                .Select(c => ToDomain(c))
                .ToListAsync();
        }

        public async Task SaveAsync(Competence domainCompetence)
        {
            var competence = ToPersistence(domainCompetence);
            appDbContext.Competences.Update(competence);
            await SaveAsync();
        }

        public async Task SaveAsync() => await appDbContext.SaveChangesAsync();
        private Competence ToDomain(CompetenceEntity competence) => Competence.Load(competence.Id, competence.Name);

        private CompetenceEntity ToPersistence(Competence domainCompetence)
        {
            return new CompetenceEntity()
            {
                Id = domainCompetence.Id,
                Name = domainCompetence.Name,
            };
        }
    }
}

using JobMatching.Domain.Entities.Language;
using JobMatching.Domain.Repositories;
using JobMatching.Infrastructure.DataAccess;
using JobMatching.Infrastructure.DataAccess.Entities;
using JobMatching.Infrastructure.QueryExtensions;
using Microsoft.EntityFrameworkCore;

namespace JobMatching.Infrastructure.Repositories
{
    public class LanguageRepository(AppDbContext appDbContext) : ILanguageRepository
    {
        public async Task<IEnumerable<Language>> GetAsync(bool withTracking = false)
        {
            return await appDbContext.Languages
                .AddTracking(withTracking)
                .Select(l => ToDomain(l))
                .ToListAsync();
        }

        public async Task SaveAsync(Language domianLanguage)
        {
            var language = ToPersistence(domianLanguage);
            appDbContext.Languages.Update(language);
            await SaveAsync();
        }

        public async Task SaveAsync() => await appDbContext.SaveChangesAsync();
        private Language ToDomain(LanguageEntity language) => Language.Load(language.Id, language.Name);

        private LanguageEntity ToPersistence(Language domainLanguage)
        {
            return new LanguageEntity()
            {
                Id = domainLanguage.Id,
                Name = domainLanguage.Name,
            };
        }
    }
}

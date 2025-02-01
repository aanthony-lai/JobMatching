using JobMatching.Domain.Entities.Language;

namespace JobMatching.Domain.Repositories
{
    public interface ILanguageRepository
    {
        Task<IEnumerable<Language>> GetAsync(bool withTracking = false);
        Task SaveAsync(Language domainLanguage);
        Task SaveAsync();
    }
}

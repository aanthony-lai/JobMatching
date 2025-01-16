using JobMatching.Domain.Entities.Language;

namespace JobMatching.Domain.Repositories
{
    public interface ILanguageRepository
    {
        Task<List<Language>> GetAsync(bool withTracking = false);
        Task SaveAsync(Language language);
    }
}

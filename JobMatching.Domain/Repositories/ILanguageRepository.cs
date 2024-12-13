using JobMatching.Domain.Entities.Language;

namespace JobMatching.Domain.Repositories
{
    public interface ILanguageRepository
    {
        Task<List<Language>> GetAsync(bool withTracking);
        Task<bool> SaveAsync(Language language);
        Task<bool> UpdateAsync(Language language);
    }
}

using JobMatching.Domain.Entities.Language;
using JobMatching.Domain.Repositories;

namespace JobMatching.Application.LanguageServices
{
    public class LanguageService(ILanguageRepository languageRepository) : ILanguageService
    {
        public async Task<IEnumerable<Language>> GetAsync() => await languageRepository.GetAsync();
    }
}

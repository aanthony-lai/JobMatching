using JobMatching.Domain.Entities.Language;
using JobMatching.Domain.Repositories;

namespace JobMatching.Application.LanguageServices
{
    public class LanguageService : ILanguageService
    {
        private readonly ILanguageRepository _languageRepository;

        public LanguageService(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public async Task<List<Language>> GetAsync()
        {
            return await _languageRepository.GetAsync();
        }
    }
}

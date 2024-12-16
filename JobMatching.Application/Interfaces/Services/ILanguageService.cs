using JobMatching.Domain.Entities.Language;

namespace JobMatching.Application.Interfaces.Services
{
    public interface ILanguageService
    {
        Task<List<Language>> GetAsync();
    }
}

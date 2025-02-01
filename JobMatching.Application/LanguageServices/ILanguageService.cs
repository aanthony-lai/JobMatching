﻿using JobMatching.Domain.Entities.Language;

namespace JobMatching.Application.LanguageServices
{
    public interface ILanguageService
    {
        Task<IEnumerable<Language>> GetAsync();
    }
}

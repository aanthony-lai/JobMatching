﻿using JobMatching.DataAccess.Context;
using JobMatching.DataAccess.QueryExtensions;
using JobMatching.Domain.Entities.Language;
using JobMatching.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JobMatching.Infrastructure.Repositories
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly AppDbContext _appDbContext;

        public LanguageRepository(AppDbContext appDbContext) 
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Language>> GetAsync(bool withTracking = false)
        {
            return await _appDbContext.Languages
                .AddTracking(withTracking)
                .ToListAsync();
        }
    }
}

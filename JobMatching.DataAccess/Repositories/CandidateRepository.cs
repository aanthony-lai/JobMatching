using JobMatching.DataAccess.Context;
using JobMatching.DataAccess.QueryExtensions;
using JobMatching.Domain.Entities;
using JobMatching.Domain.Entities.JunctionEntities;
using JobMatching.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JobMatching.DataAccess.Repositories;

public class CandidateRepository : ICandidateRepository
{
    private readonly AppDbContext _appDbContext;

    public CandidateRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Candidate?> GetByIdAsync(Guid candidateId, bool withTracking = true)
    {
        return await _appDbContext.Candidates
            .AddTracking(withTracking)
            .Include(c => c.Competences)
            .Include(c => c.JobApplications)
                .ThenInclude(ja => ja.Job.Employer)
            .Include(c => c.Languages)
                .ThenInclude(lan => lan.Language)
            .FirstOrDefaultAsync(u => u.Id == candidateId);
    }

    public async Task<List<Candidate>> GetAllAsync(bool withTracking = true)
    {
        return await _appDbContext.Candidates
            .AddTracking(withTracking)
            .Include(c => c.Competences)
            .Include(c => c.JobApplications)
                .ThenInclude(ja => ja.Job.Employer)
            .Include(c => c.Languages)
                .ThenInclude(lan => lan.Language)
            .ToListAsync();
    }

    public async Task AddAsync(Candidate candidate)
    {
        await _appDbContext.Candidates.AddAsync(candidate);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<CandidateLanguage> AddCandidateLanguageAsync(CandidateLanguage candidateLanguage)
    {
        await _appDbContext.CandidateLanguages.AddAsync(candidateLanguage);
        await _appDbContext.SaveChangesAsync();
        return candidateLanguage;
    }

    public async Task UpdateAsync(Candidate candidate)
    {
        candidate.MetaData.SetUpdatedAt();
        _appDbContext.Candidates.Update(candidate);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(Guid candidateId) =>
        await _appDbContext.Candidates.AnyAsync(c => c.Id == candidateId);
}
using JobMatching.DataAccess.Context;
using JobMatching.DataAccess.QueryExtensions;
using JobMatching.Domain.Entities.Candidate;
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

    public async Task<List<Candidate>> GetAsync(bool withTracking = false)
    {
        return await _appDbContext.Candidates
            .AddTracking(withTracking)
            .Include(c => c.JobApplications)
            .Include(c => c.CandidateLanguages)
            .Include(c => c.CandidateCompetences)
            .ToListAsync();
    }

    public async Task<Candidate?> GetByIdAsync(Guid candidateId, bool withTracking = false)
    {
        return await _appDbContext.Candidates
            .AddTracking(withTracking)
            .Where(c => c.Id == candidateId)
            .Include(c => c.JobApplications)
            .Include(c => c.CandidateLanguages)
            .Include(c => c.CandidateCompetences)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Candidate>> GetByIdsAsync(IEnumerable<Guid> ids, bool withTracking = false)
    {
        return await _appDbContext.Candidates
            .AddTracking(withTracking)
            .Where(c => ids.Contains(c.Id))
            .Include(c => c.JobApplications)
            .Include(c => c.CandidateLanguages)
            .Include(c => c.CandidateCompetences)
            .ToListAsync();
    }

    public async Task SaveAsync(Candidate candidate)
    {
        await _appDbContext.Candidates.AddAsync(candidate);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Candidate candidate)
    {
        _appDbContext.Candidates.Update(candidate);
        await _appDbContext.SaveChangesAsync();
    }
}
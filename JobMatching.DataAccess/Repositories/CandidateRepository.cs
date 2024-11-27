using JobMatching.Application.Interfaces;
using JobMatching.DataAccess.Context;
using JobMatching.DataAccess.QueryExtensions;
using JobMatching.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobMatching.DataAccess.Repositories;

public class CandidateRepository: ICandidateRepository
{
    private readonly AppDbContext _appDbContext;

    public CandidateRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    
    public async Task<Candidate?> GetCandidateByIdAsync(Guid candidateId, bool withTracking = true)
    {
        return await _appDbContext.Candidates
            .AddTracking(withTracking)
            .Include(c => c.Competences)
            .FirstOrDefaultAsync(u => u.Id == candidateId);
    }

    public async Task<List<Candidate>> GetCandidatesAsync(bool withTracking = true)
    {
        return await _appDbContext.Candidates
            .AddTracking(withTracking)
			.Include(u => u.Competences)
			.ToListAsync();
    }

    public async Task UpdateCandidateAsync(Candidate candidate)
    {
		try
		{
			_appDbContext.Candidates.Update(candidate);
			await _appDbContext.SaveChangesAsync();
		}
		catch (Exception)
		{
			throw new InvalidOperationException("An error occured while trying to save the changes.");
		}
	}

    public async Task<bool> CandidateExistsAsync(Guid candidateId)
    {
        return await _appDbContext.Candidates.AnyAsync(c => c.Id == candidateId);
    }
}
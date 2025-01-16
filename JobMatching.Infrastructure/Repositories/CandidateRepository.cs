using JobMatching.Domain.Domain.Candidate.Entities;
using JobMatching.Domain.Repositories;
using JobMatching.Infrastructure.DataAccess;
using JobMatching.Infrastructure.DataAccess.Entities;
using JobMatching.Infrastructure.QueryExtensions;
using Microsoft.EntityFrameworkCore;

namespace JobMatching.Infrastructure.Repositories;

public class CandidateRepository(AppDbContext appDbContext) : ICandidateRepository
{
    public async Task<ICollection<Candidate>> GetAsync(bool withTracking = false)
    {
        return await appDbContext.Candidates
            .AddTracking(withTracking)
                .Include(c => c.JobApplications)
                .Include(c => c.Languages)
                .Include(c => c.Competences)
            .Select(c => ToDomain(c))
            .ToListAsync();
    }

    public async Task<Candidate?> GetByIdAsync(Guid candidateId, bool withTracking = false)
    {
        return await appDbContext.Candidates
            .AddTracking(withTracking)
                .Include(c => c.JobApplications)
                .Include(c => c.Languages)
                .Include(c => c.Competences)
            .Select(c => ToDomain(c))
            .FirstOrDefaultAsync(c => c.Id == candidateId);
    }

    public async Task SaveAsync(Candidate domainCandidate)
    {
        var candidate = ToPersistence(domainCandidate);
        appDbContext.Update(candidate);
        await SaveAsync();
    }

    public async Task SaveAsync() => await appDbContext.SaveChangesAsync();

    private Candidate ToDomain(CandidateEntity candidate)
    {
        return Candidate.Load(
                candidate.Id,
                candidate.FirstName,
                candidate.LastName,
                candidate.UserId,
                candidate.JobApplications.Select(c => c.Id).ToList(),
                candidate.Languages.Select(l => l.LanguageId).ToList(),
                candidate.Competences.Select(c => c.CompetenceId).ToList());
    }

    private CandidateEntity ToPersistence(Candidate domainCandidate)
    {
        return new CandidateEntity()
        {
            Id = domainCandidate.Id,
            FirstName = domainCandidate.Name.FirstName,
            LastName = domainCandidate.Name.LastName,
            UserId = domainCandidate.UserId
        };
    }
}
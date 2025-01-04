using JobMatching.Common.Results;
using JobMatching.Domain.Entities.Candidate;

namespace JobMatching.Domain.DomainServices.CreateCandidateService
{
    public interface ICreateCandidateService
    {
        Result<Candidate> Create();
    }
}

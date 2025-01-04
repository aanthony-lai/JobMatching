using JobMatching.Common.Results;
using JobMatching.Domain.Entities.Employer;

namespace JobMatching.Domain.DomainServices.CreateEmployerService
{
    public interface ICreateEmployerService
    {
        Result<Employer> Create();
    }
}

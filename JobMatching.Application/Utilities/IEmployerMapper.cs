using JobMatching.Application.DTO.Employer;
using JobMatching.Domain.Entities.Employer;

namespace JobMatching.Application.Utilities
{
    public interface IEmployerMapper
    {
        EmployerDTO MapToEmployerDto(Employer employer);
    }
}

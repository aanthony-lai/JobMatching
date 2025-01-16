using JobMatching.Application.DTO.Employer;
using JobMatching.Domain.Domain.Employer.Entities;

namespace JobMatching.Application.Utilities
{
    public interface IEmployerMapper
    {
        EmployerDTO MapToEmployerDto(Employer employer);
    }
}

using JobMatching.Application.DTO.Employer;
using JobMatching.Domain.Entities.Employer;

namespace JobMatching.Application.Interfaces.Mappers
{
    public interface IEmployerMapper
    {
        EmployerDTO ToDto(Employer employer);
    }
}

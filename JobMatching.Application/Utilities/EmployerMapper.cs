using JobMatching.Application.DTO.Employer;
using JobMatching.Domain.Domain.Employer.Entities;

namespace JobMatching.Application.Utilities
{
    public class EmployerMapper : IEmployerMapper
    {
        public EmployerDTO MapToEmployerDto(Employer employer)
        {
            return new EmployerDTO(
                Name: employer.Name,
                Jobs: employer.JobIds.Select(id => id).ToList());
        }
    }
}

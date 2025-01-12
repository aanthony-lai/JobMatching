using JobMatching.Application.DTO.Employer;
using JobMatching.Domain.Entities.Employer;

namespace JobMatching.Application.Utilities
{
    public class EmployerMapper : IEmployerMapper
    {
        public EmployerDTO MapToEmployerDto(Employer employer)
        {
            return new EmployerDTO(
                Name: employer.Name,
                Jobs: employer.EmployerJobs.Select(j => j.JobId).ToList());
        }
    }
}

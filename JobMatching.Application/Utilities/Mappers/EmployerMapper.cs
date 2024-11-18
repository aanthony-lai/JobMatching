using JobMatching.Application.DTO;
using JobMatching.Domain.Entities;

namespace JobMatching.Application.Utilities.Mappers
{
    public static class EmployerMapper
    {
        public static EmployerDTO? Map(Employer employer)
        {
            if (employer is null)
                throw new ArgumentNullException("Cannot map null to EmployerDTO", nameof(employer));

            return new EmployerDTO(
                employerId: employer.EmployerId,
                employerName: employer.EmployerName,
                jobs: EmployerJobsMapper.Map(employer.Jobs));
        }
    }
}

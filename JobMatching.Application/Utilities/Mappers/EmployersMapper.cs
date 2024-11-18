using JobMatching.Application.DTO;
using JobMatching.Domain.Entities;

namespace JobMatching.Application.Utilities.Mappers
{
    public static class EmployersMapper
    {
        public static List<EmployerDTO?> Map(List<Employer> employers)
        {
            return employers.Select(EmployerMapper.Map).ToList();
        }
    }
}

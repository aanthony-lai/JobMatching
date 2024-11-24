using JobMatching.Application.DTO.Employer;
using JobMatching.Domain.Entities;

namespace JobMatching.Application.Utilities
{
	public static class EmployerMapper
	{
		public static EmployerDTO MapEmployer(Employer employer)
		{
			if (employer is null)
				throw new ArgumentNullException("Cannot map null to EmployerDTO", nameof(employer));

			return new EmployerDTO(
				employerId: employer.EmployerId,
				employerName: employer.EmployerName,
				jobs: JobMapper.MapJobs(employer.Jobs));
		}

		public static List<EmployerDTO> MapEmployers(List<Employer> employers) => 
			employers.Select(MapEmployer).ToList();
	}
}

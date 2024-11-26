using JobMatching.Application.DTO.Employer;
using JobMatching.Application.Interfaces;
using JobMatching.Application.Utilities;

namespace JobMatching.Application.Services
{
    public class EmployerService : IEmployerService
	{
		private readonly IEmployerRepository _employerRepository;

		public EmployerService(IEmployerRepository employerRepository)
		{
			_employerRepository = employerRepository;
		}

		public async Task<EmployerDTO?> GetEmployerByIdAsync(Guid employerId)
		{
			var employer = await _employerRepository.GetEmployerByIdAsync(employerId, withTracking: false);

			if (employer is null)
				return null;

			return EmployerMapper.MapEmployer(employer);
		}

		public async Task<List<EmployerDTO>> GetEmployersAsync()
		{
			var employers = await _employerRepository.GetEmployersAsync(withTracking: false);

			return EmployerMapper.MapEmployers(employers)!;
		}
	}
}

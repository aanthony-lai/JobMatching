using JobMatching.Application.DTO.Employer;
using JobMatching.Application.Interfaces;
using JobMatching.Application.Utilities;
using JobMatching.Common.Results;
using JobMatching.Domain.Entities;
using JobMatching.Domain.Errors;

namespace JobMatching.Application.Services
{
    public class EmployerService : IEmployerService
	{
		private readonly IEmployerRepository _employerRepository;

		public EmployerService(IEmployerRepository employerRepository)
		{
			_employerRepository = employerRepository;
		}

		public async Task<List<EmployerDTO>> GetAllAsync()
		{
			var employers = await _employerRepository.GetEmployersAsync(withTracking: false);

			return EmployerMapper.MapEmployers(employers);
		}

		public async Task<Result<EmployerDTO>> GetByIdAsync(Guid employerId)
		{
			var employer = await _employerRepository.GetEmployerByIdAsync(employerId, withTracking: false);

			if (employer is null)
				return Result<EmployerDTO>.Failure(EmployerErrors.NotFound);

			return Result<EmployerDTO>.Success(
				EmployerMapper.MapEmployer(employer));
		}

		public async Task<Result<Employer>> AddAsync(CreateEmployerDTO dto)
		{
			Result<Employer> employerResult = Employer.Create(dto.Name, dto.Email);

			if (!employerResult.IsSuccess)
				return Result<Employer>.Failure(employerResult.Error);

			await _employerRepository.SaveEmployerAsync(employerResult.Value);
			return Result<Employer>.Success(employerResult.Value);
		}
	}
}

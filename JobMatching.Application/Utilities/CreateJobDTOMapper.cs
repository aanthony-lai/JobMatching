using JobMatching.Application.DTO.Job;
using JobMatching.Domain.Entities;
using JobMatching.Domain.ValueObjects;

namespace JobMatching.Application.Utilities
{
	public static class CreateJobDTOMapper
	{
		public static Job MapCreateJobDTO(CreateJobDTO createJobDto)
		{
			return new Job(
				jobTitle: createJobDto.jobTitle,
				employerId: createJobDto.EmployerId,
				salaryRange: new SalaryRange(
					createJobDto.salaryRange.SalaryRangeTop,
					createJobDto.salaryRange.SalaryRangeBottom));
		}
	}
}

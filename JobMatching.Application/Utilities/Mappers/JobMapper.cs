using JobMatching.Application.DTO;
using JobMatching.Domain.Entities;

namespace JobMatching.Application.Utilities.Mappers
{
	public static class JobMapper
	{
		public static JobDTO? Map(Job job)
		{
			if (job is null)
				throw new ArgumentNullException("Cannot map null to JobDTO.", nameof(job));

			return new JobDTO(
				jobId: job.JobId,
				jobTitle: job.JobTitle,
				salaryTop: job.JobSalaryRange.SalaryRangeTop,
				salaryBottom: job.JobSalaryRange.SalaryRangeBottom,
				employerName: job.Employer.EmployerName,
				competencesDto: CompetencesMapper.Map(job.Competences));
		}
	}
}

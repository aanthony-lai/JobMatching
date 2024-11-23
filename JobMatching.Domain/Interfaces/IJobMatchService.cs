using JobMatching.Domain.Entities;

namespace JobMatching.Domain.Interfaces
{
	public interface IJobMatchService
	{
		decimal CalculateMatchGrade(JobApplication jobApplication);
	}
}

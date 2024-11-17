using JobMatching.Domain.Enums;

namespace JobMatching.Domain.Entities
{
	public class Application
	{
		public Guid ApplicationId { get; private set; }
		public Guid UserId { get; private set; }
		public User User { get; private set; } = null!;
		public Guid JobId { get; private set; }
		public Job Job { get; private set; } = null!;
		public DateTime ApplicationDate { get; private set; }
		public ApplicationStatus ApplicationStatus { get; private set; }
	}
}

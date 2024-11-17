using JobMatching.Domain.Enums;

namespace JobMatching.Domain.Entities
{
	public class JobApplication
	{
		private Guid _applicationUserId;
		private Guid _applicationJobId;
		
		public Guid ApplicationId { get; private set; }

		public Guid ApplicationUserId
		{
			get => _applicationUserId;
			private set
			{
				if (value == Guid.Empty)
					throw new ArgumentException(
						"An application must contain a valid User Id.",
						nameof(ApplicationUserId));
				_applicationUserId = value;
			}
		}
		public User ApplicationUser { get; private set; }

		public Guid ApplicationJobId
		{
			get => _applicationJobId;
			private set
			{
				if (value == Guid.Empty)
					throw new ArgumentException(
						"An application must contain a valid Job ID.", 
						nameof(ApplicationJobId));
				_applicationJobId = value;
			}
		}
		public Job ApplicationJob { get; private set; }
		public DateTime ApplicationDate { get; private set; }
		public ApplicationStatus ApplicationStatus { get; private set; }

		// public Application(Guid userId, Guid jobId)
		// {
		// 	ApplicationId = Guid.NewGuid();
		// 	ApplicationDate = DateTime.UtcNow;
		// 	ApplicationStatus = ApplicationStatus.Pending;
		// }
	}
}

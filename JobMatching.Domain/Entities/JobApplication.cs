using JobMatching.Domain.Enums;

namespace JobMatching.Domain.Entities
{
	public class JobApplication
	{
		private Guid _userId;
		private Guid _jobId;

		public Guid JobApplicationId { get; init; }

		public Guid UserId
		{
			get => _userId;
			private set
			{
				if (value == Guid.Empty)
					throw new ArgumentException(
						"An application must contain a valid User Id.",
						nameof(UserId));
				_userId = value;
			}
		}
		public User User { get; private set; }

		public Guid JobId
		{
			get => _jobId;
			private set
			{
				if (value == Guid.Empty)
					throw new ArgumentException(
						"An application must contain a valid Job ID.",
						nameof(JobId));

				_jobId = value;
			}
		}
		public Job Job { get; private set; }

		public DateTime ApplicationDate { get; private set; }

		public ApplicationStatus ApplicationStatus { get; private set; }

		protected JobApplication() { }

		public JobApplication(Guid userId, Guid jobId)
		{
			UserId = userId;
			JobId = jobId;
			JobApplicationId = Guid.NewGuid();
			ApplicationDate = DateTime.UtcNow;
			ApplicationStatus = ApplicationStatus.Pending;
		}
	}
}

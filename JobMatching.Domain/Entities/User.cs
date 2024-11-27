namespace JobMatching.Domain.Entities
{
	public class User
	{
		private string _email;

		public Guid Id { get; init; }
		public string Email
		{
			get => _email;
			private set
			{
				if (string.IsNullOrEmpty(value))
					throw new ArgumentNullException(nameof(value),
						"Email can't be empty.");
				if (!value.Contains("@"))
					throw new ArgumentException(nameof(value),
						"You have provided an invalid email.");
			}
		}
		public bool IsEmployer { get; init; }

		protected User() { }

		public User(
			string email,
			bool isEmployer)
		{
			Id = Guid.NewGuid();
			Email = email;
			IsEmployer = isEmployer;
		}

		protected void SetEmail(string email) => Email = email;
	}
}

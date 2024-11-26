namespace JobMatching.Domain.Entities
{
	public class User
	{
		public string Name { get; private set; } = null!;
		public string Email { get; private set; } = null!;
		public bool IsEmployer { get; init; }

		//protected User() { }
		protected User() { }

		public User(
			string firstName,
			string lastName,
			string email,
			bool isEmployer = false)
		{
			if (string.IsNullOrWhiteSpace(email) ||
				!email.Contains("@"))
			{
				throw new ArgumentException(nameof(email), "You have provided an invalid email.");

			}
			Name = $"{firstName} {lastName}";
			Email = email;
			IsEmployer = isEmployer;
		}

		public User(
			string employerName,
			string email,
			bool isEmployer = true)
		{
			if (string.IsNullOrWhiteSpace(email) ||
				!email.Contains("@"))
			{
				throw new ArgumentException(nameof(email), "You have provided an invalid email.");

			}
			Name = employerName;
			Email = email;
			IsEmployer = isEmployer;
		}
	}
}

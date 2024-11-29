namespace JobMatching.Domain.Entities
{
	public class User
	{
		private string _email;

		public Guid Id { get; init; }
		public string Email { get; private set; }
		public bool IsEmployer { get; init; }

		protected User() { }
		public User(
			string email,
			bool isEmployer)
		{
			if (string.IsNullOrEmpty(email))
				throw new ArgumentNullException(nameof(email),
					"Email can't be empty.");
			if (!email.Contains("@"))
				throw new ArgumentException(nameof(email),
					"You have provided an invalid email.");

			Id = Guid.NewGuid();
			Email = email;
			IsEmployer = isEmployer;
		}

		protected void SetEmail(string email) => Email = email;
	}
}

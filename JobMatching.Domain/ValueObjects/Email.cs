namespace JobMatching.Domain.ValueObjects
{
	public class Email
	{
		public string Address { get; } = null!;

		public Email(string address)
		{
			if (string.IsNullOrEmpty(address))
				throw new ArgumentNullException(nameof(address),
					"Email can't be empty.");
			if (!address.Contains("@"))
				throw new ArgumentException(nameof(address),
					"You have provided an invalid email.");

			Address = address;
		}

		public override string ToString() => Address;
	}
}

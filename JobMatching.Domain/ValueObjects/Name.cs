namespace JobMatching.Domain.ValueObjects
{
	public class Name
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }	

		public Name(string firstName, string lastName)
		{
			if (string.IsNullOrWhiteSpace(firstName))
				throw new ArgumentNullException("First name can't be empty.", nameof(firstName));
			if (string.IsNullOrWhiteSpace(lastName))
				throw new ArgumentNullException("Last name can't be empty.", nameof(firstName));

			FirstName = firstName.Trim();
			LastName = lastName.Trim();
		}
	}
}

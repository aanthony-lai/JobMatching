namespace JobMatching.Domain.ValueObjects.Name
{
    public class Name
    {
        public string? FirstName { get; }
        public string? LastName { get; }
        public string? EmployerName { get; }
        public string? UserName { get; set; }

        public static Name SetCandidateName(string firstName, string lastName) => 
            new Name(firstName, lastName);
        public static Name SetEmployerName(string employerName) => 
            new Name(employerName);

        public Name() { }
        private Name(string firstName, string lastName)
        {
            FirstName = string.IsNullOrWhiteSpace(firstName)
                ? throw new ArgumentNullException(nameof(firstName), "First name can't be empty.")
                : firstName.Trim();

            LastName = string.IsNullOrWhiteSpace(lastName)
                ? throw new ArgumentNullException(nameof(firstName), "Last name can't be empty.")
                : lastName.Trim();

            UserName = $"{firstName} {lastName}";
        }

        private Name(string employerName)
        {
            EmployerName = string.IsNullOrWhiteSpace(employerName)
				? throw new ArgumentNullException(nameof(employerName), "Employer name can't be empty.")
                : employerName.Trim();

            UserName = employerName;
		}
	}
}

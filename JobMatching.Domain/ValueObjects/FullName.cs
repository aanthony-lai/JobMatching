namespace JobMatching.Domain.ValueObjects.Name
{
    public class FullName
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public FullName(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentNullException(nameof(firstName), "First name can't be empty.");
            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentNullException(nameof(firstName), "Last name can't be empty.");

            FirstName = firstName.Trim();
            LastName = lastName.Trim();
        }
    }
}

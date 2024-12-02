using JobMatching.Domain.Interfaces;
using JobMatching.Domain.Types;
using JobMatching.Domain.ValueObjects;
using JobMatching.Domain.ValueObjects.Name;

namespace JobMatching.Domain.Entities
{
	public class User : IEntity
	{
		public Guid Id { get; init; }
		public Name Name { get; private set; }
		public Email Email { get; private set; }
		public UserType UserType { get; init; }
		public MetaData MetaData { get; private set; } = null!;

		protected User() { }
		private User(string emailAddress, string name, UserType userType)
		{
			Id = Guid.NewGuid();
			Email = new Email(emailAddress);
			Name = new Name() { UserName = name };
			UserType = userType;
			MetaData = new MetaData();
		}

		public static User CreateUserAsEmployer(string emailAddress, string name) =>
			new User(emailAddress, name, userType: UserType.Employer);
		public static User CreateUserCandidate(string emailAddress, string name) =>
			new User(emailAddress, name, userType: UserType.Candidate);

		public void SetEmail(string email)
		{
			Email = new Email(email);
		}
	}
}

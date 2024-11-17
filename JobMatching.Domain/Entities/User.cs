using JobMatching.Domain.ValueObjects;

namespace JobMatching.Domain.Entities
{
	public class User
	{
		private string _userEmail = null!;

		public Guid UserId { get; init; }
		public Name UserName { get; private set; } = null!;
		public List<Competence> UserCompetences { get; private set; } = new List<Competence>();
		public List<JobApplication> UserApplications { get; private set; } = new List<JobApplication>();

		// public User(string firstName, string lastName, string email)
		// {
		// 	
		// 	UserId = Guid.NewGuid();
		// 	UserName = new Name(firstName, lastName);
		// }
		//
		// public User (Name name, string email)
		// {
		// 	UserId = Guid.NewGuid();
		// 	UserName = name;
		// }

		public void AddCompetence(Competence competence)
		{
			UserCompetences.Add(competence);
		}
	}
}

using JobMatching.Common.Results;
using JobMatching.Domain.Entities.ValueObjects;
using JobMatching.Domain.Errors;
using JobMatching.Domain.Interfaces;

namespace JobMatching.Domain.Entities
{
    public class Competence: IEntity
	{
		public Guid Id { get; init; }
		public string Name { get; private set; } = null!;
		public List<Candidate> Candidates { get; private set; } = new List<Candidate>();
		public MetaData MetaData { get; private set; } = null!;

		protected Competence() { }
		private Competence(string name)
		{
			Id = Guid.NewGuid();
			Name = name;
			MetaData = new MetaData();
		}

		public static Result<Competence> Create(string name)
		{
			if (string.IsNullOrWhiteSpace(name))
				return Result<Competence>.Failure(CompetenceErrors.NameIsEmpty);

			return Result<Competence>.Success(new Competence(name));
		}
	}
}

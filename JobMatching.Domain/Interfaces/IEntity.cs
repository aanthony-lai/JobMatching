using JobMatching.Domain.ValueObjects;

namespace JobMatching.Domain.Interfaces
{
	public interface IEntity
	{
		public Guid Id { get; init; }
		public MetaData MetaData { get; }
	}
}

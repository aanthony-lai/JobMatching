using JobMatching.Domain.Entities.ValueObjects;
using JobMatching.Domain.Interfaces;

namespace JobMatching.Domain.Entities;

public class Language: IEntity
{
    public Guid Id { get; init; }
    public string Name { get; } = null!;
    public MetaData MetaData { get; } = null!;

    protected Language() { }
}
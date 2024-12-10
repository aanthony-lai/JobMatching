using JobMatching.Domain.Interfaces;
using JobMatching.Domain.ValueObjects;

namespace JobMatching.Domain.Entities;

public class Language: IEntity
{
    public Guid Id { get; init; }
    public string Name { get; } = null!;
    public MetaData MetaData { get; } = null!;

    protected Language() { }
}
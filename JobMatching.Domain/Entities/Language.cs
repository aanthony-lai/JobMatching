using JobMatching.Domain.Interfaces;
using JobMatching.Domain.ValueObjects;

namespace JobMatching.Domain.Entities;

public class Language: IEntity
{
    public Guid Id { get; init; }
    public string Name { get; }
    public LanguageProficiencyLevel LanguageProficiencyLevel { get; private set; }
    public MetaData MetaData { get; }
}
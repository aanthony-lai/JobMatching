using JobMatching.Domain.Interfaces;
using JobMatching.Domain.ValueObjects;

namespace JobMatching.Domain.Entities;

public class LanguageProficiencyLevel: IEntity
{
    public Guid Id { get; init; }
    public string Level { get; } = string.Empty;
    public List<Language> Languages { get; } = new();
    public MetaData MetaData { get; }
    
    protected LanguageProficiencyLevel() { }
}
using JobMatching.Common.Results;
using JobMatching.Domain.Errors;

namespace JobMatching.Domain.Entities.Language
{
    public class Language: DomainEntityBase
    {
        public string Name { get; }
        
        private Language(string name) 
        {
            base.Id = Guid.NewGuid();
            Name = name;
        }

        private Language(Guid id, string name) 
        {
            Id = id;
            Name = name;
        }

        public static Result<Language> Create(string name) 
        {
            return string.IsNullOrWhiteSpace(name)
                ? Result<Language>.Failure(LanguageErrors.InvalidName)
                : Result<Language>.Success(new Language(name)); ;
        }

        public static Language Load(Guid id, string name) => 
            new Language(id, name);
    }
}

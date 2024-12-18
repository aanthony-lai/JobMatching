using JobMatching.Common.Results;
using JobMatching.Domain.Errors;

namespace JobMatching.Domain.Entities.Language
{
    public class Language: EntityBase
    {
        public string Name { get; } = null!;

        protected Language() { }
        private Language(string name) 
        {
            Name = name;
        }

        public static Result<Language> Create(string name) 
        {
            if (string.IsNullOrWhiteSpace(name))
                return Result<Language>.Failure(LanguageErrors.InvalidName);

            return Result<Language>.Success(new Language(name));
        }
    }
}

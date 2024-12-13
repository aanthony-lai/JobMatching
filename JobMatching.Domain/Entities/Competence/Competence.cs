using JobMatching.Common.Results;
using JobMatching.Domain.BaseClasses;
using JobMatching.Domain.Errors;

namespace JobMatching.Domain.Entities.Competence
{
    public class Competence: EntityBase
    {
        public string Name { get; } = null!;

        protected Competence() { }
        private Competence(string name) => Name = name;
        
        public static Result<Competence> Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Result<Competence>.Failure(CompetenceErrors.InvalidName);

            return Result<Competence>.Success(new Competence(name));
        }
    }
}

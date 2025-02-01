using JobMatching.Common.Results;
using JobMatching.Domain.Errors;

namespace JobMatching.Domain.Entities.Competence
{
    public class Competence: DomainEntityBase
    {
        public string Name { get; }

        private Competence(string name)
        {
            base.Id = Guid.NewGuid();
            Name = name;
        }

        private Competence(Guid id, string name)
        {
            base.Id = id;
            Name = name;
        }
        
        public static Result<Competence> Create(string name)
        {
            return string.IsNullOrWhiteSpace(name) 
                ? Result<Competence>.Failure(CompetenceErrors.InvalidName)
                : Result<Competence>.Success(new Competence(name));
        }

        public static Competence Load(Guid id, string name) => 
            new Competence(id, name);
    }
}

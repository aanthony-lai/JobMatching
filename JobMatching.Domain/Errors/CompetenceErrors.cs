using JobMatching.Common.Results;

namespace JobMatching.Domain.Errors
{
    public static class CompetenceErrors
    {
        public static readonly Error Invalid = new("Invalid competence.");
        public static readonly Error AlreadyExists = new("The selected competence has already been added.");
        public static readonly Error NameIsEmpty = new("Competence name can't be empty.");
    }
}

using JobMatching.Common.Results;

namespace JobMatching.Domain.Errors
{
    public static class NameErrors
    {
        public static readonly Error FirstNameIsEmpty = new("First name can't be empty.");
        public static readonly Error LastNameIsEmpty = new("Last name can't be empty");
        public static readonly Error EmployerNameIsEmpty = new("Employer name can't be empty.");
    }
}

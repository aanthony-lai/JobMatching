using JobMatching.Common.Results;

namespace JobMatching.Domain.Errors
{
    public static class CompetenceErrors
    {
        public static readonly Error InvalidName = new("Competence name can't be empty.");
    }
}

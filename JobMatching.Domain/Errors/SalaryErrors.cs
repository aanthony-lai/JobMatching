using JobMatching.Common.Results;

namespace JobMatching.Domain.Errors
{
    public static class SalaryErrors
    {
        public static readonly Error InvalidSalaryRange = new("Maximum salary can't be lower than minimum salary.");
    }
}

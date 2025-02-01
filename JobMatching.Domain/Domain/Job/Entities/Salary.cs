using JobMatching.Common.Results;
using JobMatching.Domain.Errors;

namespace JobMatching.Domain.Domain.Job.Entities
{
    public record Salary
    {
        public int MaxSalary { get; }
        public int MinSalary { get; }

        private Salary(int maxSalary, int minSalary)
        {
            MaxSalary = maxSalary;
            MinSalary = minSalary;
        }

        public static Result<Salary> Create(int maxSalary, int minSalary)
        {
            if (maxSalary < 0 || minSalary < 0)
                return Result<Salary>.Failure(JobErrors.SalaryNegativeValue);

            if (maxSalary < minSalary)
                return Result<Salary>.Failure(JobErrors.InvalidSalaryRange);

            return Result<Salary>.Success(new Salary(maxSalary, minSalary));
        }

        public static Salary Load(int maxSalary, int minSalary) => 
            new Salary(maxSalary, minSalary);
    }
}

using JobMatching.Common.Results;
using JobMatching.Domain.Errors;

namespace JobMatching.Domain.Entities.ValueObjects
{
    public class Salary
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
            if (maxSalary < minSalary)
                return Result<Salary>.Failure(SalaryErrors.InvalidSalaryRange);

            return Result<Salary>.Success(new Salary(maxSalary, minSalary));
        }
    }
}
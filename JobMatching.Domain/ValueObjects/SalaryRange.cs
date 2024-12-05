namespace JobMatching.Domain.ValueObjects
{
    public class SalaryRange
    {
        public int SalaryRangeTop { get; set; }
        public int SalaryRangeBottom { get; set; }

        public SalaryRange(int salaryRangeTop, int salaryRangeBottom)
        {
            if (salaryRangeTop < salaryRangeBottom)
                throw new ArgumentOutOfRangeException(nameof(salaryRangeTop),
                    "The upper salary range can't be lower than the lower salary range.");

            SalaryRangeTop = salaryRangeTop;
            SalaryRangeBottom = salaryRangeBottom;
        }
    }
}
﻿namespace JobMatching.Domain.ValueObjects
{
	public class SalaryRange
	{
		public int SalaryRangeTop { get; set; }
		public int SalaryRangeBottom { get; set; }
	
		public SalaryRange(int salaryRangeTop, int salaryRangeBottom)
		{
			if (salaryRangeTop < salaryRangeBottom)
				throw new ArgumentException("Invalid salary range.");

			SalaryRangeTop = salaryRangeTop;
			SalaryRangeBottom = salaryRangeBottom;
		}
	}
}

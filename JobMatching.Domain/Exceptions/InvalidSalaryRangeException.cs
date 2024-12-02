namespace JobMatching.Domain.Exceptions
{
	public class InvalidSalaryRangeException: Exception
	{
		public InvalidSalaryRangeException() : base() { }
		public InvalidSalaryRangeException(string message) : base(message) { }
		public InvalidSalaryRangeException(string message, Exception inner) : base(message, inner) { }
	}
}

namespace JobMatching.Application.Exceptions
{
	public class JobNotFoundException: Exception
	{
		public JobNotFoundException() : base() { }
		public JobNotFoundException(string message) : base(message) { }
		public JobNotFoundException(string message, Exception inner) : base(message, inner) { }
	}
}

namespace JobMatching.Domain.Exceptions
{
	public class DuplicateJobApplicationsException: Exception
	{
		public DuplicateJobApplicationsException() : base() { }
		public DuplicateJobApplicationsException(string message) : base(message) { }
		public DuplicateJobApplicationsException(string message, Exception inner) : base(message, inner) { }
	}
}

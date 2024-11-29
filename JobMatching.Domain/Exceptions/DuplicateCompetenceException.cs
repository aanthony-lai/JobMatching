namespace JobMatching.Domain.Exceptions
{
	public class DuplicateCompetenceException: Exception
	{
		public DuplicateCompetenceException(): base() { }
		public DuplicateCompetenceException(string message): base(message) { }
		public DuplicateCompetenceException(string message, Exception inner): base(message, inner) { }
	}
}

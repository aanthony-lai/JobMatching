namespace JobMatching.Application.Exceptions
{
	public class CompetenceNotFoundException: Exception
	{
		public CompetenceNotFoundException(): base() { }
		public CompetenceNotFoundException(string message): base(message) { }
		public CompetenceNotFoundException(string message, Exception inner): base(message, inner) { }
	}
}

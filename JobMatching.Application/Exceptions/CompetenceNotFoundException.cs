namespace JobMatching.Application.Exceptions
{
	public class CompetenceNotFoundException: Exception
	{
		public CompetenceNotFoundException(string message): base(message) { }
	}
}

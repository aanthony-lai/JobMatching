namespace JobMatching.Application.Exceptions
{
	public class CandidateNotFoundException: Exception
	{
		public CandidateNotFoundException(): base() { }
		public CandidateNotFoundException(string message): base(message) { }
		public CandidateNotFoundException(string message, Exception inner) : base(message, inner) { }
	}
}

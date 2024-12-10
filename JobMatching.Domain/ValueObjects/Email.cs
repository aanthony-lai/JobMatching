using JobMatching.Common.Results;
using JobMatching.Domain.Errors;

namespace JobMatching.Domain.ValueObjects
{
	public class Email
	{
		public string Address { get; } = null!;

		private Email(string address)
		{
			Address = address;
		}

		public static Result<Email> SetEmail(string address)
		{
			if (string.IsNullOrWhiteSpace(address))
				return Result<Email>.Failure(EmailErrors.EmailIsEmpty);

			if (!address.Contains("@"))
				return Result<Email>.Failure(EmailErrors.InvalidEmail);

			return Result<Email>.Success(new Email(address));
		}

		public override string ToString() => Address;
	}
}

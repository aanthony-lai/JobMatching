using JobMatching.Common.Results;

namespace JobMatching.Domain.Errors
{
    public static class LanguageErrors
    {
        public static readonly Error InvalidName = new("Language name can't be emtpy.");
    }
}

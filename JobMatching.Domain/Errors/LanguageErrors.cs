using JobMatching.Common.Results;

namespace JobMatching.Domain.Errors
{
    public class LanguageErrors
    {
        public static readonly Error InvalidLanguage = new("Invalid language.");
        public static readonly Error LanguageAlreadyExists = new("The selected language has already been added.");
        public static readonly Error InvalidCandidateId = new("Invalid candidate ID.");
        public static readonly Error InvalidLanguageId = new("Invalid language ID.");
    }
}

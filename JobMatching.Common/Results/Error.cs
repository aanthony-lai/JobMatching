namespace JobMatching.Common.Results
{
    public record Error(string Description)
    {
        public static Error None = new(string.Empty);

        public override string ToString()
        {
            return Description;
        }
    }
}

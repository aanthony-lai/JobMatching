namespace JobMatching.Common.Exceptions
{
    public class EntityAlreadyExistException : Exception
    {
        public EntityAlreadyExistException() : base() { }
        public EntityAlreadyExistException(string message) : base(message) { }
        public EntityAlreadyExistException(string message, Exception inner) : base(message, inner) { }
    }
}

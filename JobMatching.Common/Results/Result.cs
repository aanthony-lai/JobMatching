namespace JobMatching.Common.Results
{
    public class Result
    {
        private readonly Error _error;
        private readonly bool _isSuccess;
        
        public Error Error { get { return _error; } }
        public bool IsSuccess { get { return _isSuccess; } }

        protected Result() 
        {
            _error = Error.None;
            _isSuccess = true;
        }

        protected Result(Error error)
        {
            _error= error;
            _isSuccess= false;
        }

        public static Result Success() => new();
        public static Result Failure(Error error) => new(error);
    }


    public class Result<TValue>: Result
    {
        private readonly TValue? _value;

        private Result(TValue value): base()
        {
            _value = value;
        }

        private Result(Error error): base(error)
        {
            _value = default;
        }

        public TValue Value 
        { 
            get 
            {
                if (!IsSuccess) throw new InvalidOperationException("No value present for a failed result.");
                return _value!; 
            } 
        }

        public static Result<TValue> Success(TValue value)
            => new(value);
        public static Result<TValue> Failure(Error error)
            => new(error);

        public static implicit operator Result<TValue>(TValue value) 
            => new(value);

        public static implicit operator Result<TValue>(Error error)
            => new(error);

        public TResult Match<TResult>(
            Func<TValue, TResult> success,
            Func<Error, TResult> failure)
        {
            return base.IsSuccess ? success(_value!) : failure(base.Error);
        }
    }
}

namespace Gasolutions.Core.Patterns.Result
{
    public class Result<T>
    {
        private Result(T value, bool isSuccess, Error error)
        {
            if ((isSuccess && error != Error.None) ||
                (!isSuccess && error == Error.None))
            {
                throw new ArgumentException("Invalid error", nameof(error));
            }

            this.Value = value;
            this.IsSuccess = isSuccess;
            this.Error = error;
        }

        public T Value { get; }

        public bool IsSuccess { get; }

        public bool IsFailure => !this.IsSuccess;

        public Error Error { get; }

        public static Result<T> Success(T value)
        {
            return new Result<T>(value, true, Error.None);
        }

        public static Result<T> Failure(Error error)
        {
            return new(default, false, error);
        }

        public static Result<T> FailureWithValue(Error error, T value)
        {
            return new(value, false, error);
        }
    }
}

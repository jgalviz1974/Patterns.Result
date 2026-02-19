namespace Gasolutions.Core.Patterns.Result
{
    public class ResultResponse<T>
    {
        public ResultResponse()
        {
            this.Value = default!;
            this.IsSuccess = false;
            this.IsFailure = false;
            this.Error = Error.None;
        }

        public T Value { get; set; }

        public bool IsSuccess { get; set; }

        public bool IsFailure { get; set; }

        public Error Error { get; set; }
    }
}

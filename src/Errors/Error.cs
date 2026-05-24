namespace Gasolutions.Core.Patterns.Result.Errors
{
    public sealed record Error(string Code, string Description, string ClassName, string MethodName)
    {
        public static readonly Error None = new(string.Empty, string.Empty, string.Empty, string.Empty);

        public static Error Create(string description, string method)
        {
            StackTraceInfo stackTraceInfo = StackTraceHelper.RetrieveCallerInfo(1);
            return new Error(stackTraceInfo.ErrorCode, description, stackTraceInfo.CallerClassName, method);
        }

        public Error AddToDescription(string message) =>
           this with { Description = $"{this.Description} {message}" };

        public Error AppendToDescription(string message) =>
          this with { Description = $"{message} {this.Description}" };

        internal static Error Create(string code, string description, string method)
        {
            StackTraceInfo stackTraceInfo = StackTraceHelper.RetrieveCallerInfo(1);
            return new Error(code, description, stackTraceInfo.CallerClassName, method);
        }
    }
}
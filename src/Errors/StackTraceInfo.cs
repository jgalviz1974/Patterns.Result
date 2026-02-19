namespace Gasolutions.Core.Patterns.Result.Errors
{
    /// <summary>
    /// Contains stack trace information extracted from the call stack.
    /// This class encapsulates caller context information used for error reporting.
    /// </summary>
    public class StackTraceInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StackTraceInfo"/> class.
        /// </summary>
        public StackTraceInfo()
        {
            this.ClassName = string.Empty;
            this.MethodName = string.Empty;
            this.CallerClassName = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StackTraceInfo"/> class with caller context.
        /// </summary>
        /// <param name="callerClassName">The name of the class that called the error factory method.</param>
        /// <param name="className">The name of the error factory class.</param>
        /// <param name="methodName">The name of the error factory method.</param>
        public StackTraceInfo(string callerClassName, string className, string methodName)
        {
            this.CallerClassName = callerClassName;
            this.ClassName = className;
            this.MethodName = methodName;
        }

        /// <summary>
        /// Gets or sets the name of the class that called the error factory method.
        /// </summary>
        public string CallerClassName { get; set; }

        /// <summary>
        /// Gets the complete error code combining class and method names.
        /// </summary>
        public string ErrorCode => $"{this.ClassName}.{this.MethodName}";

        /// <summary>
        /// Gets or sets the name of the error factory class.
        /// This is used internally to construct the error code.
        /// </summary>
        private string ClassName { get; set; }

        /// <summary>
        /// Gets or sets the name of the error factory method.
        /// This is used internally to construct the error code.
        /// </summary>
        private string MethodName { get; set; }
    }
}
using System.Diagnostics;
using System.Reflection;

namespace Gasolutions.Core.Patterns.Result.Errors
{
    /// <summary>
    /// Utility class to retrieve caller information from the call stack.
    /// </summary>
    public static class StackTraceHelper
    {
        /// <summary>
        /// Generates an error code combining the error factory class name and method name.
        /// Both are obtained from the immediate caller (error factory method).
        /// </summary>
        /// <param name="frameOffset">Additional frames to skip when the call is wrapped by an intermediary (e.g., Error.Create).</param>
        /// <returns>Error code in format "ErrorFactoryClassName.MethodName".</returns>
        public static StackTraceInfo RetrieveCallerInfo(int frameOffset = 0)
        {
            StackTrace stackTrace = new(true);
            MethodBase? callerMethodBase = stackTrace.GetFrame(2 + frameOffset)?.GetMethod();
            string callerClassName = callerMethodBase?.DeclaringType?.Name ?? string.Empty;

            MethodBase? methodBase = stackTrace.GetFrame(1 + frameOffset)?.GetMethod();
            string className = methodBase?.DeclaringType?.Name ?? string.Empty;
            string methodName = methodBase?.Name ?? string.Empty;
            StackTraceInfo info = new(callerClassName, className, methodName);
            return info;
        }
    }
}
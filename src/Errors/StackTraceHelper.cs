using System.Diagnostics;
using System.Reflection;

namespace Gasolutions.Core.Patterns.Result.Errors
{
    /// <summary>
    /// Utility class to retrieve caller information from the call stack.
    /// </summary>
    internal static class StackTraceHelper
    {
        /// <summary>
        /// Generates an error code combining the error factory class name and method name.
        /// Both are obtained from the immediate caller (error factory method).
        /// </summary>
        /// <returns>Error code in format "ErrorFactoryClassName.MethodName".</returns>
        internal static StackTraceInfo RetrieveCallerInfo()
        {
            StackTrace stackTrace = new(true);
            MethodBase? callerMethodBase = stackTrace.GetFrame(2)?.GetMethod();
            string callerClassName = callerMethodBase?.DeclaringType?.Name ?? string.Empty;

            MethodBase? methodBase = stackTrace.GetFrame(1)?.GetMethod();
            string className = methodBase?.DeclaringType?.Name ?? string.Empty;
            string methodName = methodBase?.Name ?? string.Empty;
            StackTraceInfo info = new(callerClassName, className, methodName);
            return info;
        }
    }
}
namespace Gasolutions.Core.Patterns.Result.Errors
{
    /// <summary>
    /// Contains error methods that are related to other, non-specific errors.
    /// </summary>
    public static class OtherErrors
    {
        /// <summary>
        /// Creates an error indicating that something is not defined.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="methodName">The name of the method where the error occurred.</param>
        /// <returns>An Error object containing the error details.</returns>
        public static Error NotDefined(string message, [CallerMemberName] string methodName = "")
        {
            return Error.Create($"{message}", methodName);
        }

        /// <summary>
        /// Creates an error indicating a communication issue with multiple services.
        /// </summary>
        /// <param name="services">The services involved in the communication error.</param>
        /// <param name="methodName">The name of the method where the error occurred.</param>
        /// <returns>An Error object containing the error details.</returns>
        public static Error CommunicationError(string[] services, [CallerMemberName] string methodName = "")
        {
            string serviceList = string.Join(", ", services);
            return Error.Create(ErrorMessages.Get("OtherErrors_CommunicationError", serviceList), methodName);
        }

        /// <summary>
        /// Creates an error indicating that multiple messages were expected, but not all were received.
        /// </summary>
        /// <param name="expected">The expected messages.</param>
        /// <param name="received">The received messages.</param>
        /// <param name="methodName">The name of the method where the error occurred.</param>
        /// <returns>An Error object containing the error details.</returns>
        public static Error MessageMismatch(string[] expected, string[] received, [CallerMemberName] string methodName = "")
        {
            string expectedList = string.Join(", ", expected);
            string receivedList = string.Join(", ", received);
            return Error.Create(ErrorMessages.Get("OtherErrors_MessageMismatch", expectedList, receivedList), methodName);
        }
    }
}

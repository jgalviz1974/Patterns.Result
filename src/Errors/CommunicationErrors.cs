namespace Gasolutions.Core.Patterns.Result.Errors
{
    /// <summary>
    /// Factory class for creating communication-related errors.
    /// </summary>
    public static class CommunicationErrors
    {
        /// <summary>
        /// Error when communication with a service fails.
        /// </summary>
        /// <param name="nameService">Name of the service.</param>
        /// <param name="message">Details of the communication error.</param>
        /// <param name="method">Method that generates the error.</param>
        /// <returns>An Error object with the corresponding code and message.</returns>
        public static Error CommunicationError(string nameService, string message, [CallerMemberName] string method = "")
        {
            return Error.Create($"Error al tratar de conectar a {nameService}: {message}", method);
        }
    }
}

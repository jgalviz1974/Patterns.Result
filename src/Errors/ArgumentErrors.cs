namespace Gasolutions.Core.Patterns.Result.Errors
{
    /// <summary>
    /// Factory class for creating argument validation errors.
    /// </summary>
    public static class ArgumentErrors
    {
        /// <summary>
        /// Error when an argument is not valid.
        /// </summary>
        /// <param name="type">Type of the argument.</param>
        /// <param name="nameObject">Name of the argument.</param>
        /// <param name="messsage">Description of the validation error.</param>
        /// <param name="method">Method that generates the error.</param>
        /// <returns>An Error object with the corresponding code and message.</returns>
        public static Error NoValid(string type, string nameObject, string messsage, [CallerMemberName] string method = "")
        {
            return Error.Create($"{nameObject} de tipo {type} {messsage}.", method);
        }
    }
}

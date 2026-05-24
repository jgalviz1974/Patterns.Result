using System.Text.RegularExpressions;

namespace Gasolutions.Core.Patterns.Result.Errors
{
    public static class DatabaseErrors
    {
        private static readonly Regex ForeingKeyInformationRegex = new(@"FOREIGN KEY \(`(?<Field>\w+)`\) REFERENCES `(?<Table>\w+)` \(`(?<RefField>\w+)`\)");

        /// <summary>
        /// Error when no records exist in a table.
        /// </summary>
        /// <param name="nameEntity">Name of the entity.</param>
        /// <param name="method">Method that generates the error.</param>
        /// <returns>An Error object with the corresponding code and message.</returns>
        public static Error TableWithoutRegisters(string nameEntity, [CallerMemberName] string method = "")
        {
            return Error.Create(ErrorMessages.Get("DatabaseErrors_TableWithoutRegisters", nameEntity), method);
        }

        /// <summary>
        /// Error when a record is not found by its ID.
        /// </summary>
        /// <param name="nameEntity">Name of the entity.</param>
        /// <param name="id">ID of the record.</param>
        /// <param name="isMale">Indicates if the entity name is masculine.</param>
        /// <param name="method">Method that generates the error.</param>
        /// <returns>An Error object with the corresponding code and message.</returns>
        public static Error NotFound(string nameEntity, int id, bool isMale = true, [CallerMemberName] string method = "")
        {
            string key = isMale ? "DatabaseErrors_NotFoundMale" : "DatabaseErrors_NotFoundFemale";
            return Error.Create(ErrorMessages.Get(key, nameEntity, id), method);
        }

        /// <summary>
        /// Error when a record is not found by its ID.
        /// </summary>
        /// <param name="nameEntity">Name of the entity.</param>
        /// <param name="nameField">ID of the record.</param>
        /// <param name="isMale">Indicates if the entity name is masculine.</param>
        /// <param name="method">Method that generates the error.</param>
        /// <returns>An Error object with the corresponding code and message.</returns>
        public static Error NotFound(string nameEntity, string nameField, bool isMale = true, [CallerMemberName] string method = "")
        {
            string key = isMale ? "DatabaseErrors_NotFoundByFieldMale" : "DatabaseErrors_NotFoundByFieldFemale";
            return Error.Create(ErrorMessages.Get(key, nameEntity, nameField), method);
        }

        /// <summary>
        /// Error when a record is not found by a specific field.
        /// </summary>
        /// <param name="nameEntity">Name of the entity.</param>
        /// <param name="nameField">Name of the field.</param>
        /// <param name="value">Value of the field.</param>
        /// <param name="isMale">Indicates if the entity name is masculine.</param>
        /// <param name="method">Method that generates the error.</param>
        /// <returns>An Error object with the corresponding code and message.</returns>
        public static Error NotFound(string nameEntity, string nameField, string value, bool isMale = true, [CallerMemberName] string method = "")
        {
            string key = isMale ? "DatabaseErrors_NotFoundByValueMale" : "DatabaseErrors_NotFoundByValueFemale";
            return Error.Create(ErrorMessages.Get(key, nameEntity, nameField, value), method);
        }

        /// <summary>
        /// Error when no records exist in a table with a specific message.
        /// </summary>
        /// <param name="nameEntity">Name of the entity.</param>
        /// <param name="message">Additional message.</param>
        /// <param name="method">Method that generates the error.</param>
        /// <returns>An Error object with the corresponding code and message.</returns>
        public static Error TableWithoutRegisters(string nameEntity, string message, [CallerMemberName] string method = "")
        {
            return Error.Create(ErrorMessages.Get("DatabaseErrors_TableWithoutRegistersMessage", message, nameEntity), method);
        }

        /// <summary>
        /// Error when a record fails to update.
        /// </summary>
        /// <param name="nameEntity">Name of the entity.</param>
        /// <param name="id">ID of the record.</param>
        /// <param name="message">Message explaining the reason for the update failure.</param>
        /// <param name="isMale">Indicates if the entity name is masculine.</param>
        /// <param name="method">Method that generates the error.</param>
        /// <returns>An Error object with the corresponding code and message.</returns>
        public static Error NotUpdated(string nameEntity, int id, string message, bool isMale = true, [CallerMemberName] string method = "")
        {
            string key = isMale ? "DatabaseErrors_NotUpdatedMale" : "DatabaseErrors_NotUpdatedFemale";
            return Error.Create(ErrorMessages.Get(key, nameEntity, id, message), method);
        }

        /// <summary>
        /// Error when attempting to delete a record that has associated sales.
        /// </summary>
        /// <param name="entity">Name of the entity.</param>
        /// <param name="stationId">ID of the station.</param>
        /// <param name="method">Method that generates the error.</param>
        /// <returns>An Error object with the corresponding code and message.</returns>
        public static Error AssociatedRegisters(string entity, int stationId, [CallerMemberName] string method = "")
        {
            return Error.Create(ErrorMessages.Get("DatabaseErrors_AssociatedRegisters", entity, stationId), method);
        }

        /// <summary>
        /// Error when a foreign key constraint is violated.
        /// </summary>
        /// <param name="entity">Name of the entity.</param>
        /// <param name="errorMessage">Error message from the database.</param>
        /// <param name="method">Method that generates the error.</param>
        /// <returns>An Error object with the corresponding code and message.</returns>
        public static Error ForeingRelationViolated(string entity, string errorMessage, [CallerMemberName] string method = "")
        {
            string table = string.Empty;
            string refField = string.Empty;

            Match match = ForeingKeyInformationRegex.Match(errorMessage);

            if (match.Success)
            {
                _ = match.Groups["Field"].Value;
                table = match.Groups["Table"].Value;
                refField = match.Groups["RefField"].Value;
            }

            return Error.Create(ErrorMessages.Get("DatabaseErrors_ForeignRelationViolated", entity, table, refField), method);
        }
    }
}

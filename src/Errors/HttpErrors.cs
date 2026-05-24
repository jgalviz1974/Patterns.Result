// <copyright file="HttpErrors.cs" company="Gasolutions SAS">
// Copyright (c) Gasolutions SAS. Todos los derechos reservados.
// </copyright>

namespace Gasolutions.Core.Patterns.Result.Errors
{
    /// <summary>
    /// Proporciona definiciones de errores para operaciones HTTP.
    /// </summary>
    public static class HttpErrors
    {
        /// <summary>
        /// Retorna un error indicando que la URL especificada no está autorizada.
        /// </summary>
        /// <param name="url">La URL a la que no se tiene autorización.</param>
        /// <returns>Una instancia de <see cref="Error"/> que representa el error de no autorizado.</returns>
        public static Error UnAuthorized(string url, [CallerMemberName] string method = "")
        {
            return Error.Create(ErrorMessages.Get("HttpErrors_UnAuthorized", url), method);
        }

        public static Error BadResponse(string type, string content, [CallerMemberName] string method = "")
        {
            return Error.Create(ErrorMessages.Get("HttpErrors_BadResponse", type, content), method);
        }

        public static Error InternalServerError(string content, [CallerMemberName] string method = "")
        {
            return Error.Create(content, method);
        }

        public static Error General(string code, string content, [CallerMemberName] string method = "")
        {
            return Error.Create($"Error code {code}: {content}", method);
        }
    }
}

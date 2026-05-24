// <copyright file="EmailErrors.cs" company="Gasolutions SAS">
// Copyright (c) Gasolutions SAS. Todos los derechos reservados.
// </copyright>

namespace Gasolutions.Core.Patterns.Result.Errors
{
    /// <summary>
    /// Fábrica de errores de dominio para el flujo de autenticación.
    /// Sigue el mismo patrón de <c>DatabaseErrors</c> del NuGet Gasolutions.Core.
    /// </summary>
    public static class EmailErrors
    {
        /// <summary>
        /// Se produjo una respuesta inválida del proveedor de correo electrónico.
        /// </summary>
        public static Error InvalidResponse([CallerMemberName] string method = "")
        {
            return Error.Create("Invalid response from email provider.", method);
        }

        /// <summary>
        /// Se produjo una respuesta inválida del proveedor de correo electrónico.
        /// </summary>
        public static Error InvalidResponse(string message, [CallerMemberName] string method = "")
        {
            return Error.Create($"Invalid response from email provider: {message}", method);
        }

        /// <summary>
        /// Un campo obligatorio no fue provisto.
        /// </summary>
        public static Error Others(string message, [CallerMemberName] string method = "")
        {
            return Error.Create(message, method);
        }
    }
}

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
            StackTraceInfo stack = StackTraceHelper.RetrieveCallerInfo();
            return new Error(stack.ErrorCode, "Invalid response from email provider.", stack.CallerClassName, method);
        }

        /// <summary>
        /// Se produjo una respuesta inválida del proveedor de correo electrónico.
        /// </summary>
        public static Error InvalidResponse(string message, [CallerMemberName] string method = "")
        {
            StackTraceInfo stack = StackTraceHelper.RetrieveCallerInfo();
            return new Error(stack.ErrorCode, $"Invalid response from email provider: {message}", stack.CallerClassName, method);
        }

        /// <summary>
        /// Un campo obligatorio no fue provisto.
        /// </summary>
        public static Error Others(string message, [CallerMemberName] string method = "")
        {
            StackTraceInfo stack = StackTraceHelper.RetrieveCallerInfo();
            return new Error(stack.ErrorCode, message, stack.CallerClassName, method);
        }
    }
}

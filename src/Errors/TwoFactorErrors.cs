// <copyright file="TwoFactorErrors.cs" company="Gasolutions SAS">
// Copyright (c) Gasolutions SAS. Todos los derechos reservados.
// </copyright>

namespace Gasolutions.Core.Patterns.Result.Errors
{
    /// <summary>
    /// Fábrica de errores de dominio para el flujo de habilitación y deshabilitación de 2FA.
    /// Sigue el mismo patrón de <c>DatabaseErrors</c> del NuGet Gasolutions.Core.
    /// </summary>
    public static class TwoFactorErrors
    {
        /// <summary>
        /// El correo del usuario no se encuentra confirmado.
        /// </summary>
        public static Error EmailNotConfirmed([CallerMemberName] string method = "")
        {
            StackTraceInfo stack = StackTraceHelper.RetrieveCallerInfo();
            return new Error("TwoFactorErrors.EmailNotConfirmed", "El correo del usuario no se encuentra confirmado.", stack.CallerClassName, method);
        }

        /// <summary>
        /// No se encontró el usuario solicitado.
        /// </summary>
        public static Error UserNotFound(string userId, [CallerMemberName] string method = "")
        {
            StackTraceInfo stack = StackTraceHelper.RetrieveCallerInfo();
            return new Error("TwoFactorErrors.UserNotFound", $"No se encontró el usuario '{userId}'.", stack.CallerClassName, method);
        }

        /// <summary>
        /// El OTP proporcionado no es válido.
        /// </summary>
        public static Error OtpInvalid([CallerMemberName] string method = "")
        {
            StackTraceInfo stack = StackTraceHelper.RetrieveCallerInfo();
            return new Error("TwoFactorErrors.OtpInvalid", "El OTP proporcionado no es válido.", stack.CallerClassName, method);
        }

        /// <summary>
        /// El OTP ha expirado.
        /// </summary>
        public static Error OtpExpired([CallerMemberName] string method = "")
        {
            StackTraceInfo stack = StackTraceHelper.RetrieveCallerInfo();
            return new Error("TwoFactorErrors.OtpExpired", "El OTP ha expirado.", stack.CallerClassName, method);
        }

        /// <summary>
        /// Las credenciales proporcionadas no son válidas.
        /// </summary>
        public static Error InvalidCredentials([CallerMemberName] string method = "")
        {
            StackTraceInfo stack = StackTraceHelper.RetrieveCallerInfo();
            return new Error("TwoFactorErrors.InvalidCredentials", "Usuario no validado o contraseña incorrecta.", stack.CallerClassName, method);
        }
    }
}

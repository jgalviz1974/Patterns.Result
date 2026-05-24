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
            return Error.Create(ErrorMessages.Get("TwoFactorErrors_EmailNotConfirmed"), method);
        }

        /// <summary>
        /// No se encontró el usuario solicitado.
        /// </summary>
        public static Error UserNotFound(string userId, [CallerMemberName] string method = "")
        {
            return Error.Create(ErrorMessages.Get("TwoFactorErrors_UserNotFound", userId), method);
        }

        /// <summary>
        /// El OTP proporcionado no es válido.
        /// </summary>
        public static Error OtpInvalid([CallerMemberName] string method = "")
        {
            return Error.Create(ErrorMessages.Get("TwoFactorErrors_OtpInvalid"), method);
        }

        /// <summary>
        /// El OTP ha expirado.
        /// </summary>
        public static Error OtpExpired([CallerMemberName] string method = "")
        {
            return Error.Create(ErrorMessages.Get("TwoFactorErrors_OtpExpired"), method);
        }

        /// <summary>
        /// Las credenciales proporcionadas no son válidas.
        /// </summary>
        public static Error InvalidCredentials([CallerMemberName] string method = "")
        {
            return Error.Create(ErrorMessages.Get("TwoFactorErrors_InvalidCredentials"), method);
        }
    }
}

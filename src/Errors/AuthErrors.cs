// <copyright file="AuthErrors.cs" company="Gasolutions SAS">
// Copyright (c) Gasolutions SAS. Todos los derechos reservados.
// </copyright>

namespace Gasolutions.Core.Patterns.Result.Errors
{
    /// <summary>
    /// Fábrica de errores de dominio para el flujo de autenticación.
    /// Sigue el mismo patrón de <c>DatabaseErrors</c> del NuGet Gasolutions.Core.
    /// </summary>
    public static class AuthErrors
    {
        /// <summary>
        /// El usuario existe pero está marcado como bloqueado en el sistema.
        /// </summary>
        public static Error UserBlocked(string userName, [CallerMemberName] string method = "")
        {
            return Error.Create($"El usuario '{userName}' se encuentra bloqueado.", method);
        }

        /// <summary>
        /// Las credenciales (usuario o contraseña) son incorrectas,
        /// o el rol del usuario no está permitido en esta aplicación.
        /// El mensaje es intencionalmente genérico para no revelar información.
        /// </summary>
        public static Error InvalidCredentials([CallerMemberName] string method = "")
        {
            return Error.Create("Usuario no validado o contraseña incorrecta.", method);
        }

        /// <summary>
        /// Un campo obligatorio no fue provisto.
        /// </summary>
        public static Error RequiredField(string fieldName, string message)
        {
            return Error.Create(message, "RequiredField");
        }

        /// <summary>
        /// La firma XML del assertion SAML no es válida o no coincide con el certificado del IdP.
        /// El mensaje al usuario es genérico para no exponer detalles de seguridad.
        /// </summary>
        public static Error SamlSignatureInvalid([CallerMemberName] string method = "")
        {
            return Error.Create("No se pudo completar la autenticación. Por favor contacte al administrador.", method);
        }

        /// <summary>
        /// El assertion no contiene firma y RequireSignedAssertion está activo.
        /// </summary>
        public static Error SamlAssertionNotSigned([CallerMemberName] string method = "")
        {
            return Error.Create("No se pudo completar la autenticación. Por favor contacte al administrador.", method);
        }

        /// <summary>
        /// La audiencia del assertion no coincide con el SpEntityId configurado.
        /// </summary>
        public static Error SamlAudienceMismatch([CallerMemberName] string method = "")
        {
            return Error.Create("No se pudo completar la autenticación. Por favor contacte al administrador.", method);
        }

        /// <summary>
        /// El emisor del assertion no coincide con el IdpEntityId configurado.
        /// </summary>
        public static Error SamlIssuerMismatch([CallerMemberName] string method = "")
        {
            return Error.Create("No se pudo completar la autenticación. Por favor contacte al administrador.", method);
        }

        /// <summary>
        /// El assertion está fuera del rango de validez temporal (NotBefore / NotOnOrAfter).
        /// </summary>
        public static Error SamlAssertionExpired([CallerMemberName] string method = "")
        {
            return Error.Create("No se pudo completar la autenticación. Por favor contacte al administrador.", method);
        }

        /// <summary>
        /// El AssertionID ya fue procesado anteriormente (ataque de replay).
        /// </summary>
        public static Error SamlReplayDetected([CallerMemberName] string method = "")
        {
            return Error.Create("No se pudo completar la autenticación. Por favor contacte al administrador.", method);
        }

        /// <summary>
        /// La configuración SAML del IdP no está disponible o el certificado ha expirado.
        /// </summary>
        public static Error SamlConfigurationUnavailable([CallerMemberName] string method = "")
        {
            return Error.Create("El sistema de autenticación empresarial no está disponible. Use login local o contacte soporte.", method);
        }

        /// <summary>
        /// El usuario no tiene permisos suficientes para realizar esta operación.
        /// </summary>
        public static Error InsufficientPermissions([CallerMemberName] string method = "")
        {
            return Error.Create("Permisos insuficientes para realizar esta operación.", method);
        }

        /// <summary>
        /// No se encontró configuración SAML para la compañía solicitada.
        /// </summary>
        public static Error SamlConfigNotFound(int companyId, [CallerMemberName] string method = "")
        {
            return Error.Create($"No se encontró configuración SAML para la compañía {companyId}.", method);
        }
    }
}

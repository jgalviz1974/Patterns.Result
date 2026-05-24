// <copyright file="KeyValueErrors.cs" company="Gasolutions SAS">
// Copyright (c) Gasolutions SAS. Todos los derechos reservados.
// </copyright>

namespace Gasolutions.Core.Patterns.Result.Errors
{
    public static class KeyValueErrors
    {
        public static Gasolutions.Core.Patterns.Result.Errors.Error NoValid(string value, [CallerMemberName] string method = "")
        {
            return Error.Create(ErrorMessages.Get("KeyValueErrors_NoValid", value), method);
        }
    }
}
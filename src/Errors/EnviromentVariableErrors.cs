// <copyright file="EnviromentVariableErrors.cs" company="Gasolutions SAS">
// Copyright (c) Gasolutions SAS. Todos los derechos reservados.
// </copyright>

namespace Gasolutions.Core.Patterns.Result.Errors
{
    public static class EnviromentVariableErrors
    {
        public static Gasolutions.Core.Patterns.Result.Errors.Error NoFound(string name, [CallerMemberName] string method = "")
        {
            return Error.Create(ErrorMessages.Get("EnviromentVariableErrors_NoFound", name), method);
        }
    }
}
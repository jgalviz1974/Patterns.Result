// <copyright file="EnviromentVariableErrors.cs" company="Gasolutions SAS">
// Copyright (c) Gasolutions SAS. Todos los derechos reservados.
// </copyright>

namespace Gasolutions.Core.Patterns.Result.Errors
{
    public static class EnviromentVariableErrors
    {
        public static Gasolutions.Core.Patterns.Result.Errors.Error NoFound(string name, [CallerMemberName] string method = "")
        {
            StackTraceInfo stack = StackTraceHelper.RetrieveCallerInfo();
            return new("EnviromentVariableErrors.NoFound", $"No se encontró la variable de entorno '{name}'", stack.CallerClassName, method);
        }
    }
}
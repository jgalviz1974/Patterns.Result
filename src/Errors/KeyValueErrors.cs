// <copyright file="KeyValueErrors.cs" company="Gasolutions SAS">
// Copyright (c) Gasolutions SAS. Todos los derechos reservados.
// </copyright>

namespace Gasolutions.Core.Patterns.Result.Errors
{
    public static class KeyValueErrors
    {
        public static Gasolutions.Core.Patterns.Result.Errors.Error NoValid(string value, [CallerMemberName] string method = "")
        {
            StackTraceInfo stack = StackTraceHelper.RetrieveCallerInfo();
            return new Gasolutions.Core.Patterns.Result.Errors.Error(stack.ErrorCode, $"La clave proporcionada no es válida: '{value}'", stack.CallerClassName, method);
        }
    }
}
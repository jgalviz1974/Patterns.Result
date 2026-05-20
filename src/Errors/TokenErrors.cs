// <copyright file="TokenErrors.cs" company="Gasolutions SAS">
// Copyright (c) Gasolutions SAS. Todos los derechos reservados.
// </copyright>

namespace Gasolutions.Core.Patterns.Result.Errors
{
    public static class TokenErrors
    {
        public static Gasolutions.Core.Patterns.Result.Errors.Error GettingProblem(string apiRestName, [CallerMemberName] string method = "")
        {
            StackTraceInfo stack = StackTraceHelper.RetrieveCallerInfo();
            return new("TokenErrors.GettingProblem", $"No se pudo obtener el token en {apiRestName} api rest.", stack.CallerClassName, method);
        }
    }
}
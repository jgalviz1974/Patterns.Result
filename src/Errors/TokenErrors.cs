// <copyright file="TokenErrors.cs" company="Gasolutions SAS">
// Copyright (c) Gasolutions SAS. Todos los derechos reservados.
// </copyright>

namespace Gasolutions.Core.Patterns.Result.Errors
{
    public static class TokenErrors
    {
        public static Error GettingProblem(string apiRestName, [CallerMemberName] string method = "")
        {
            return Error.Create(ErrorMessages.Get("TokenErrors_GettingProblem", apiRestName), method);
        }
    }
}
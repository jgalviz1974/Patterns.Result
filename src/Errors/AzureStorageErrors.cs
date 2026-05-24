// <copyright file="AzureStorageErrors.cs" company="Gasolutions SAS">
// Copyright (c) Gasolutions SAS. Todos los derechos reservados.
// </copyright>

namespace Gasolutions.Core.Patterns.Result.Errors
{
    /// <summary>
    /// Proporciona definiciones de errores para operaciones de Azure Blob Storage.
    /// </summary>
    public static class AzureStorageErrors
    {
        /// <summary>
        /// Retorna un error indicando que el blob especificado no fue encontrado en el contenedor.
        /// </summary>
        /// <param name="containerName">El nombre del contenedor.</param>
        /// <param name="blobName">El nombre del blob.</param>
        /// <returns>Una instancia de <see cref="Error"/> que representa el error de blob no encontrado.</returns>
        public static Error BlobNotFound(string containerName, string blobName, [CallerMemberName] string method = "")
        {
            return Error.Create(ErrorMessages.Get("AzureStorageErrors_BlobNotFound", blobName, containerName), method);
        }
    }
}

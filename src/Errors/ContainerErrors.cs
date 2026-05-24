namespace Gasolutions.Core.Patterns.Result.Errors
{
    public static class ContainerErrors
    {
        public static Error InvalidContainerName([CallerMemberName] string method = "")
        {
            return Error.Create("El nombre del contenedor es requerido.", method);
        }

        public static Error InvalidFileName([CallerMemberName] string method = "")
        {
            return Error.Create("El nombre del archivo es requerido.", method);
        }

        public static Error InvalidFilePath([CallerMemberName] string method = "")
        {
            return Error.Create("La ruta del archivo es requerida.", method);
        }

        public static Error LocalFileNotFound(string filePath, [CallerMemberName] string method = "")
        {
            return Error.Create($"No se encontró el archivo local '{filePath}'.", method);
        }

        public static Error InvalidContent([CallerMemberName] string method = "")
        {
            return Error.Create("El contenido del archivo es requerido.", method);
        }
    }
}

namespace Gasolutions.Core.Patterns.Result.Errors
{
    public static class ContainerErrors
    {
        public static Error InvalidContainerName([CallerMemberName] string method = "")
        {
            return Error.Create(ErrorMessages.Get("ContainerErrors_InvalidContainerName"), method);
        }

        public static Error InvalidFileName([CallerMemberName] string method = "")
        {
            return Error.Create(ErrorMessages.Get("ContainerErrors_InvalidFileName"), method);
        }

        public static Error InvalidFilePath([CallerMemberName] string method = "")
        {
            return Error.Create(ErrorMessages.Get("ContainerErrors_InvalidFilePath"), method);
        }

        public static Error LocalFileNotFound(string filePath, [CallerMemberName] string method = "")
        {
            return Error.Create(ErrorMessages.Get("ContainerErrors_LocalFileNotFound", filePath), method);
        }

        public static Error InvalidContent([CallerMemberName] string method = "")
        {
            return Error.Create(ErrorMessages.Get("ContainerErrors_InvalidContent"), method);
        }
    }
}

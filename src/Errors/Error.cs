namespace Gasolutions.Core.Patterns.Result.Errors
{
    public sealed record Error(string Code, string Description, string ClassName, string MethodName)
    {
        public static readonly Error None = new(string.Empty, string.Empty, string.Empty, string.Empty);
    }
}